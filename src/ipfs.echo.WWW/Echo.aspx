<%@ Page Language="C#" Inherits="ipfs.echo.WWW.Echo" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>ipfs-echo - Echo</title>
	<link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
	<form id="form1" runat="server">
		<h1>ipfs-echo</h1>
		<% if (DidPublish){ %>
		<div>The provided text has been published to ipfs.</div>
		<div>Text: <%= TextData %></div>
		<div>Device key: <%= DeviceKey %></div>
		<div>&nbsp;</div>
		<div>You can acces the data via the following links:</div>
		<div><a href='<%= LocalUrl %>'><%= LocalUrl %></a></div>
		<div><a href='<%= IpfsUrl %>'><%= IpfsUrl %></a></div>
		<div>&nbsp;</div>
		<div><a href="Default.aspx">&laquo; back to form</a></div>
		<% } else { %>
		<div>Invalid arguments. Publish aborted.</div>
		<% } %>
	</form>
</body>
</html>

