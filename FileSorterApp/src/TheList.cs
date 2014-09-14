using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using System.ComponentModel;

/// <summary>
/// FileData
/// </summary>
public class FileData : INotifyPropertyChanged                              ////
{
    private string _fileName;
    private string _extension;
    private string _fullPath;
    private string _destinationPath;

    public Boolean Checked { get; set; }

    public string FileName
    {
        get { return _fileName; }
        set
        {
            _fileName = value;
            this.NotifyPropertyChanged("FileName");
        }
    }

    public string Extension
    {
        get { return _extension; }
        set
        {
            _extension = value;
            this.NotifyPropertyChanged("Extension");
        }
    }

    public string FullPath
    {
        get { return _fullPath; }
        set
        {
            _fullPath = value;
            this.NotifyPropertyChanged("FullPath");
        }
    }

    public string DestinationPath
    {
        get { return _destinationPath; }
        set
        {
            _destinationPath = value;
            this.NotifyPropertyChanged("DestinationPath");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public FileData(string filePath)
    {
        _fullPath = filePath;
        _fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
        _extension = filePath.Substring(filePath.LastIndexOf(".") + 1);
        _destinationPath = "";
        Checked = false;
    }

    private void NotifyPropertyChanged(string name)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
}

/// <summary>
/// FileList<T>
/// </summary>
/// <typeparam name="T"></typeparam>
public class FileList<T> : BindingList<T> where T : FileData
{
    /*public FileList()
    {

    }*/

    public void AddElement(string filePath)
    {
        if (string.IsNullOrEmpty(filePath)) return;
        var fileData = new FileData(filePath);
        this.Add(fileData as T);
    }

    /*public void AddDestinationFolder(string extension, string destinationFolder)
    {
        for (var i = 0; i < this.Count; i++)
        {
            if (this[i].Extension == extension)
                this[i].DestinationPath = destinationFolder + this[i].FileName;
        }        
    }*/

    public void AddDestinations(ExtensionList<ExtensionData> extensions)
    {
        foreach (var t in extensions)
            for (var j = 0; j < this.Count; j++)
            {
                if (this[j].Extension == t.Extension)
                    this[j].DestinationPath = t.FullPath + this[j].FileName;
            }

        var defaultPath = extensions.GetPathByExtension("default");

        if (defaultPath == "") return;

        for (var j = 0; j < this.Count; j++)
        {
            if (this[j].DestinationPath == "")
                this[j].DestinationPath = defaultPath + this[j].FileName;
        }
    }

    public void FillListWithFiles(string[] fileNameArray)
    {
        foreach (var fileName in fileNameArray)
            this.AddElement(fileName);
    }
}

/// <summary>
/// ExtensionData
/// </summary>
public class ExtensionData : INotifyPropertyChanged                              ////
{
    private string _id;
    private string _extension;
    private string _fullPath;

    public string Id
    {
        get { return _id; }
        set
        {
            _id = value;
            this.NotifyPropertyChanged("FileName");
        }
    }

    public string Extension
    {
        get { return _extension; }
        set
        {
            _extension = value;
            this.NotifyPropertyChanged("Extension");
        }
    }

    public string FullPath
    {
        get { return _fullPath; }
        set
        {
            _fullPath = value;
            this.NotifyPropertyChanged("FullPath");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public ExtensionData(string id, string extension, string fullPath)
    {
        _id = id;
        _extension = extension;
        _fullPath = fullPath;
    }

    public ExtensionData(XmlAttributeCollection attributes)
    {
        _id = attributes[0].Value; ;
        _extension = attributes[1].Value;
        _fullPath = attributes[2].Value;
    }

    private void NotifyPropertyChanged(string name)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
}


/// <summary>
/// ExtensionList<T>
/// </summary>
/// <typeparam name="T"></typeparam>
public class ExtensionList<T> : BindingList<T> where T : ExtensionData
{
    readonly string _settingsPath;
    readonly XmlDocument _settingsXml;

    public ExtensionList(string settingsPath)
    {
        _settingsPath = settingsPath;
        var xmlFile = new FileInfo(_settingsPath);
        if (!xmlFile.Exists)
        {
            var textWriter = new XmlTextWriter(_settingsPath, Encoding.UTF8);
            textWriter.WriteStartElement("extensions");
            textWriter.WriteEndElement();
            textWriter.Close();
        }
        _settingsXml = new XmlDocument();
        _settingsXml.Load(_settingsPath);

        SetOthersNode();

        ReadExtensions();
    }

    ~ExtensionList()
    {
        WriteExtensions();
    }

    private void SetOthersNode()                      //INNER
    {
        if (_settingsXml.DocumentElement == null) return;

        var element = _settingsXml.DocumentElement.SelectSingleNode(
            string.Format("extension[@name='{0}']", "default"));
        if (element == null)
        {
            EditExtension(Guid.NewGuid().ToString(), "default", "");
        }
    }

    private XmlNode AddNode(string id)                      //INNER
    {
        if (_settingsXml.DocumentElement == null) return null;
        
        var element = _settingsXml.CreateElement("extension");
        _settingsXml.DocumentElement.AppendChild(element);
        var idAttr = _settingsXml.CreateAttribute("ID");
        idAttr.Value = id;
        element.Attributes.Append(idAttr);
        element.Attributes.Append(_settingsXml.CreateAttribute("name"));

        element.Attributes.Append(_settingsXml.CreateAttribute("dest_dir"));

        return element;
    }

    public void AddElement(string id, string ext, string path)
    {
        var element = EditExtension(id, ext, path);
        var extData = new ExtensionData(element.Attributes);
        this.Add(extData as T);
    }

    private XmlNode EditExtension(string id, string ext, string path)               //INNER
    {
        if (_settingsXml.DocumentElement == null) return null;

        var element = _settingsXml.DocumentElement.SelectSingleNode(
            String.Format("extension[@ID='{0}']", id)
            ) ?? AddNode(id);

        if (element.Attributes == null) return null;
        
        element.Attributes[1].Value = ext;
        element.Attributes[2].Value = path;
        //_settingsXml.Save(_settingsPath);

        return element;
    }

    private void ReadExtensions()                                                              //INNER         
    {
        if (_settingsXml.DocumentElement == null) return;

        var extensionCount = _settingsXml.DocumentElement.ChildNodes.Count;
        for (var i = 0; i < extensionCount; i++)
        {
            var element = _settingsXml.DocumentElement.ChildNodes[i];

            if (element.Attributes == null) continue;

            var extData = new ExtensionData(element.Attributes);
            this.Add(extData as T);                                                                 ////
        }
    }

    private void RemoveEmptyNodes()                                                                 //INNER
    {
        foreach (XmlNode node in _settingsXml.DocumentElement.ChildNodes)
        {
            if (node.Attributes == null || (node.Attributes[1].Value == "" && node.Attributes[2].Value == ""))
                _settingsXml.DocumentElement.RemoveChild(node);
        }
    }
    
    private void WriteExtensions()
    {
        if (_settingsXml.DocumentElement == null) return;

        _settingsXml.DocumentElement.RemoveAll();
        
        for (var i = 0; i < this.Count; i++)
        {
            EditExtension(this[i].Id, this[i].Extension, this[i].FullPath);
        }
        RemoveEmptyNodes();

        _settingsXml.Save(_settingsPath);
    }

    public string GetPathByExtension(string extension)
    {
        for (var i = 0; i < this.Count; i++)
        {
            if (this[i].Extension == extension)
                return this[i].FullPath;
        }
        return "";
    }
}