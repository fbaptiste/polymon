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
					.MonitorHeaderName {
					font-size: medium;
					color: blue;
					}
					.MonitorHeaderType {
					color: black;
					font-size: normal;
					font-style: italic;
					}
					.MonitorBody {
					}
					.CurrentStatus {
					color: blue;
					}
					.MonitorEvents{
					}
					.MonitorEvent{
					}
					.MonitorEventDetails {
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
				<br/>
				<br/>

				<!-- First recap current status of each Monitor for quick read -->
				<span class="MonitorHeaderName">Current Statuses</span>
				<hr/>
				<xsl:for-each select="Operator/Monitor">
					<li>
						<xsl:value-of select="@Name"/> <span class="MonitorHeaderType">
							[<xsl:value-of select="@Type"/>]
						</span>: <xsl:value-of select="CurrentStatus/@Status"/> as of <xsl:value-of select="CurrentStatus/@EventDT"/>
					</li>
				</xsl:for-each>
				<hr/>

				<br/>

				<xsl:for-each select="Operator/Monitor">
					<table cellpadding="5px" frame="none" width="100%">
						<tr>
							<td>
								<span class="MonitorHeaderName">
									<xsl:value-of select="@Name"/>
								</span>
							</td>
							<td align="right">
								<span class="MonitorHeaderType">
									(<xsl:value-of select="@Type"/>)
								</span>
							</td>
						</tr>
					</table>
					<hr/>
					<table cellpadding="5px">
						<tr>
							<td>
								<NOBR>
									Current Status: <xsl:value-of select="CurrentStatus/@Status"/>
								</NOBR>
							</td>
							<td>
								as of: <xsl:value-of select="CurrentStatus/@EventDT"/>
							</td>
						</tr>
						<tr>
							<td></td>
							<td>
								<xsl:for-each select="CurrentStatus/Events/Event">
									<li>
										<xsl:value-of select="@Status"/>
										<span class="MonitorEventDate">
											[<xsl:value-of select="@EventDT"/>]
										</span>
									</li>
									<br/>
									<div class="MonitorEventDetails">
										<xsl:value-of select="Details"/>
									</div>
								</xsl:for-each>
							</td>
						</tr>
					</table>
					<br/>
				</xsl:for-each>

			</body>
		</html>
	</xsl:template>

</xsl:stylesheet>

