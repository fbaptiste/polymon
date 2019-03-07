<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
  <head>
	<style type="text/css">
		body {
			color: black;
			font-size: small;
		}
		.MainHeader {
			color:Red;
			font-size: large;
		}
		.MonitorHeader {
			.border-bottom: 3 solid blue; 
			float: left;
			color: blue;
		}
		.MonitorHeaderName {
			font-size: medium;
			padding-left: 0px;
			float: left;
		}
		.MonitorHeaderType {
			color: black;
			font-size: normal;
			font-style: italic;
			float: right;
		}
		.MonitorBody {
			margin-left: 10px;
		}
		.CurrentStatus {
			margin-top: 5px;
			margin-bottom: 5px;
			color: blue;
		}
		.MonitorEvents{
			margin-left: 20px;
		}
		.MonitorEvent{
			margin-bottom: 3px;
		}
		.MonitorEventDetails {
			margin-left: 30px;
			font-size: small;
			font-style: italic;
			color: green;
		}
		.MonitorEventDate {
			font-style: italic;
			font-size: x-small;
		}
	</style>  
  </head>
  <body>
    <span class="MainHeader">PolyMon - Offline Alerts Recap</span>
  	<br/><br/>
  	
  	<xsl:for-each select="Operator/Monitor">
  		<div class="MonitorHeader">
  				<div class="MonitorHeaderName"><xsl:value-of select="@Name"/></div>
				<div class="MonitorHeaderType">(<xsl:value-of select="@Type"/>)</div>
  		</div>
  		<div class="MonitorBody">
  			<div class="CurrentStatus">
  				Current Status: 
				<xsl:value-of select="CurrentStatus/@Status"/>
				&#160;&#160;[<xsl:value-of select="CurrentStatus/@EventDT"/>]
			</div>
			
			<div class="MonitorEvents">
				<xsl:for-each select="CurrentStatus/Events/Event">
					<div class="MonitorEvent">
						<li>
							<xsl:value-of select="@Status"/> &#160;&#160; <span class="MonitorEventDate">[<xsl:value-of select="@EventDT"/>]</span>
							<br/>
							<div class="MonitorEventDetails"><xsl:value-of select="Details"/></div>
						</li>
					</div>
				</xsl:for-each>
			</div>
  		</div>
  	</xsl:for-each>
  
  </body>
  </html>
</xsl:template>

</xsl:stylesheet>

