<?xml version="1.0" encoding="iso-8859-1"?>
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
			font-weight: bold;
			}
			.SectionHeader {
				color: blue;
				font-size: normal;
				font-weight: bold;
			}
			
			.MonitorName {
			font-size: normal;
			color: blue;
			}
			.MonitorID {
				font-size: x-small;
			}
			.MonitorType {
			color: black;
			font-size: small;
			font-style: italic;
			}
			.Status {
			font-weight: normal;
			color: blue;
			}
			.Elapsed {
			font-size: small;
			font-style: italic;
			}
			.DateRange{
			font-size: x-small;
			font-style: normal;
			}
		</style>
	</head>
			
		<body>
		<div class="MainHeader">PolyMon Monitor Status</div>
		<br/><br/>
		
		<div class="SectionHeader" style="color: red;">Status - Fail</div>
		<hr/>
		<table>
			<xsl:apply-templates select="/CurrentStatuses/Monitor[Status[@StatusID='3']]">
				<xsl:sort select="@Name"/>
			</xsl:apply-templates>
		</table>
		
		<br/><br/>
		
		<div class="SectionHeader" style="color: orange;">Status - Warning</div>
		<hr/>
		<table>
			<xsl:apply-templates select="/CurrentStatuses/Monitor[Status[@StatusID='2']]">
				<xsl:sort select="@Name"/>
			</xsl:apply-templates>
		</table>
		
		<br/><br/>
		
		<div class="SectionHeader" style="color: green;">Status - OK</div>
		<hr/>
		<table>
			<xsl:apply-templates select="/CurrentStatuses/Monitor[Status[@StatusID='1']]">
				<xsl:sort select="@Name"/>
			</xsl:apply-templates>
		</table>
		
		</body>
	</html>
</xsl:template>

<xsl:template match="Monitor">
	<tr>
		<td align="left">
			<li>
				<span class="MonitorName"><xsl:value-of select="@Name"/> </span>
				<span class="MonitorID"> [<xsl:value-of select="@MonitorID"/>]</span>
			</li>
		</td>
		<td width="20px"></td>
		<td align="left">
			<span class="Status"><xsl:value-of select="Status"/> </span>	
		</td>
		<td align="right">
			<span class="MonitorType"><xsl:value-of select="@Type"/></span>
		</td>
	</tr>
	<tr>
		<td colspan="2"/>
		<td align="left" colspan="2">
		<span class="DateRange"><xsl:value-of select="StatusStartDT"/> - <xsl:value-of select="StatusEndDT"/></span>
		<br/>
		<span class="Elapsed"> (<xsl:value-of select="TimeElapsedTxt"/>)</span>
		</td>
	</tr>
	<tr>
		<td/>
	</tr>
</xsl:template>


</xsl:stylesheet>
