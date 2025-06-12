<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileManager.aspx.cs" Inherits="SisaAdmin.FileManager"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/reset.css" rel="stylesheet" />
    <link href="../js/jquery.filetree/jqueryFileTree.css" rel="stylesheet" />
    <link href="../js/jquery.contextmenu/jquery.contextMenu-1.01.css" rel="stylesheet" />
    <link href="../css/filemanager.css" rel="stylesheet" />
    <!--[if IE]>
    <link rel="stylesheet" type="text/css" href="styles/ie.css" />
    <![endif]-->
</head>
<body>
    <form id="uploader" method="post">
        <button id="home" name="home" type="button" value="Home">&nbsp;</button>
        <h1></h1>
        <div id="uploadresponse"></div>
        <input id="mode" name="mode" type="hidden" value="add" />
        <input id="currentpath" name="currentpath" type="hidden" />
        <span id="file-input-container">
            <div id="alt-fileinput">
                <input id="filepath" name="filepath" type="text" />
                <button id="browse" name="browse" type="button" value="Browse"></button>
            </div>
            <input id="newfile" name="newfile" type="file" />
        </span>
        <button id="upload" name="upload" type="submit" value="Upload"></button>
        <button id="newfolder" name="newfolder" type="button" value="New Folder"></button>
        <button id="grid" class="ON" type="button">&nbsp;</button>
        <button id="list" type="button">&nbsp;</button>
    </form>
    <div id="splitter">
        <div id="filetree"></div>
        <div id="fileinfo">
            <h1></h1>
        </div>
    </div>

    <ul id="itemOptions" class="contextMenu">
        <li class="select" runat="server" id="a1"><a href="#select"></a></li>
        <li class="download" runat="server" id="a2"><a href="#download"></a></li>
        <li class="rename" runat="server" id="a3"><a href="#rename"></a></li>
        <li class="delete separator" runat="server" id="a4"><a href="#delete"></a></li>
    </ul>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../js/jquery.form-3.24.js"></script>
    <script src="../js/jquery.splitter/jquery.splitter-1.5.1.js"></script>
    <script src="../js/jquery.filetree/jqueryFileTree.js"></script>
    <script src="../js/jquery.contextmenu/jquery.contextMenu-1.01.js"></script>
    <script src="../js/jquery.impromptu-3.2.min.js"></script>
    <script src="../js/jquery.tablesorter-2.7.2.min.js"></script>
    <script src="../js/filemanager.config.js"></script>
    <script src="../js/filemanager.js"></script>
</body>
</html>
