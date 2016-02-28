<%@ Page Language="C#" Inherits="ipfs.echo.WWW.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>ipfs-echo</title>
	<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
	<form id="form1" runat="server">
		<h1>ipfs-echo</h1>
		<div>To publish text data to ipfs; enter the text, the name/key/id of the device, and click submit.</div>
		<div>Text: <asp:TextBox runat="server" id="TextData"/></div>
		<div>Folder name: <asp:TextBox runat="server" id="FolderName"/> (optional)</div>
		<div>File name: <asp:TextBox runat="server" id="FileName"/> (optional)</div>
		<div>Overwrite: <asp:CheckBox runat="server" id="Overwrite"/> (leave unchecked to append)</div>
		<div><asp:Button runat="server" id="GoButton" OnClick="GoButton_Click" Text="Submit" /></div>

		<div>Note: If you provide a device key then ipns will be used to provide a persistent URL to access the data even after it's updated (ie. mutable data). Otherwise it will simply provide direct link to the ipfs hash (ie. immutable data).</div>
	</form>
</body>
</html>

