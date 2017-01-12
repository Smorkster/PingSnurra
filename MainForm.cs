using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace PingSnurra
{
	public partial class MainForm : Form
	{
		Ping pinger = new Ping();
		PingReply pReply;
		Timer pingTimer;
		PingOptions pOptions;
		DefaultOptions defaults = new DefaultOptions();
		int numberOfPings = 1, pingsmade, timeout;
		byte[] pingbuffer;
		bool ping;
		
		public MainForm()
		{
			InitializeComponent();
			pingTimer = new Timer();
			pingTimer.Interval = 1000;
			pingTimer.Tick += TimerTick;
			Text = "PingSnurra version " + System.Reflection.Assembly.GetExecutingAssembly()
				.GetName().Version;
		}

		/// <summary>
		/// Eventhandler for timertick
		/// Handles all the exceptions specified in API doc
		/// 
		/// Increase the number of pings done
		/// If a specified number of pings is to be done, stop when that number is reached
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="args">Generic EventArgs</param>
		void TimerTick (object sender, EventArgs args)
		{
			try
			{
				pReply = pinger.Send(txtAddress.Text, timeout, pingbuffer, pOptions);

				switch (pReply.Status)
				{
					case IPStatus.TimedOut:
						txtPingLog.AppendText("Pingrequest timed out.");
						break;
					case IPStatus.Success:
						txtPingLog.AppendText("Roundtriptime: " + pReply.RoundtripTime + " ms" + "\r\n");
						break;
					case IPStatus.TtlExpired:
					case IPStatus.TimeExceeded:
						txtPingLog.AppendText("The ICMP echo request failed because its Time to Live (TTL) value reached zero, causing the forwarding node (router or gateway) to discard the packet.");
						break;
					case IPStatus.DestinationHostUnreachable:
						txtPingLog.AppendText("The ICMP echo request failed because the destination computer is not reachable.");
						break;
					case IPStatus.BadDestination:
						txtPingLog.AppendText("The ICMP echo request failed because the destination IP address cannot receive ICMP echo requests or should never appear in the destination address field of any IP datagram. For example, calling Send and specifying IP address '000.0.0.0' returns this status.");
						break;
					case IPStatus.BadHeader:
						txtPingLog.AppendText("The ICMP echo request failed because the header is invalid.");
						break;
					case IPStatus.BadOption:
						txtPingLog.AppendText("The ICMP echo request failed because it contains an invalid option.");
						break;
					case IPStatus.BadRoute:
						txtPingLog.AppendText("The ICMP echo request failed because there is no valid route between the source and destination computers.");
						break;
					case IPStatus.DestinationNetworkUnreachable:
						txtPingLog.AppendText("The ICMP echo request failed because the network that contains the destination computer is not reachable.");
						break;
					case IPStatus.DestinationPortUnreachable:
						txtPingLog.AppendText("The ICMP echo request failed because the port on the destination computer is not available.");
						break;
					case (IPStatus) 11004:
						var host = Dns.GetHostEntry(txtAddress.Text);
						var ip = host.AddressList[host.AddressList.Length - 1];
						if (ip.AddressFamily == AddressFamily.InterNetwork)
							txtPingLog.AppendText("The ICMP echo request failed because the destination computer that is specified in an ICMP echo message is not reachable, because it does not support the packet's protocol. This value applies only to IPv4. This value is described in IETF RFC 1812 as Communication Administratively Prohibited.");
						else
							txtPingLog.AppendText("The ICMPv6 echo request failed because contact with the destination computer is administratively prohibited. This value applies only to IPv6.");
						break;
					case IPStatus.DestinationScopeMismatch:
						txtPingLog.AppendText("The ICMP echo request failed because the source address and destination address that are specified in an ICMP echo message are not in the same scope. This is typically caused by a router forwarding a packet using an interface that is outside the scope of the source address. Address scopes (link-local, site-local, and global scope) determine where on the network an address is valid.");
						break;
					case IPStatus.DestinationUnreachable:
						txtPingLog.AppendText("The ICMP echo request failed because the destination computer that is specified in an ICMP echo message is not reachable; the exact cause of problem is unknown.");
						break;
					case IPStatus.HardwareError:
						txtPingLog.AppendText("The ICMP echo request failed because of a hardware error.");
						break;
					case IPStatus.IcmpError:
						txtPingLog.AppendText("The ICMP echo request failed because of an ICMP protocol error.");
						break;
					case IPStatus.NoResources:
						txtPingLog.AppendText("The ICMP echo request failed because of insufficient network resources.");
						break;
					case IPStatus.PacketTooBig:
						txtPingLog.AppendText("The ICMP echo request failed because the packet containing the request is larger than the maximum transmission unit (MTU) of a node (router or gateway) located between the source and destination. The MTU defines the maximum size of a transmittable packet.");
						break;
					case IPStatus.ParameterProblem:
						txtPingLog.AppendText("The ICMP echo request failed because a node (router or gateway) encountered problems while processing the packet header. This is the status if, for example, the header contains invalid field data or an unrecognized option.");
						break;
					case IPStatus.SourceQuench:
						txtPingLog.AppendText("The ICMP echo request failed because the packet was discarded. This occurs when the source computer's output queue has insufficient storage space, or when packets arrive at the destination too quickly to be processed.");
						break;
					case IPStatus.TtlReassemblyTimeExceeded:
						txtPingLog.AppendText("The ICMP echo request failed because the packet was divided into fragments for transmission and all of the fragments were not received within the time allotted for reassembly. RFC 2460 (available at www.ietf.org) specifies 60 seconds as the time limit within which all packet fragments must be received.");
						break;
					case IPStatus.Unknown:
						txtPingLog.AppendText("The ICMP echo request failed for an unknown reason.");
						break;
					case IPStatus.UnrecognizedNextHeader:
						txtPingLog.AppendText("The ICMP echo request failed because the Next Header field does not contain a recognized value. The Next Header field indicates the extension header type (if present) or the protocol above the IP layer, for example, TCP or UDP.");
						break;
				}
				if (pReply.Status != IPStatus.Success)
					txtPingLog.AppendText("(time " + DateTime.Now + ")\r\n");
			} catch (PingException e)
			{
				pingTimer.Stop();
				txtPingLog.AppendText(e.InnerException.Message);
			} catch (ArgumentOutOfRangeException)
			{
				pingTimer.Stop();
				txtPingLog.AppendText("Value of timeout is less than zero.\r\nPinging stopped");
			} catch (ArgumentNullException)
			{
				pingTimer.Stop();
				txtPingLog.AppendText("Address is null, or buffer is null.\r\nPinging stopped");
			} catch (InvalidOperationException)
			{
				pingTimer.Stop();
				txtPingLog.AppendText("Ping is already in progress.\r\nPinging stopped");
			} catch (NotSupportedException)
			{
				pingTimer.Stop();
				txtPingLog.AppendText("address is an IPv6 address and the local computer does not support that protocol.\r\nPinging stopped");
			}

			pingsmade += 1;
			if (checkboxLoops.Checked)
			{
				if (pingsmade == numberOfPings)
				{
					pingTimer.Stop();
					txtPingLog.AppendText(numberOfPings + " pings done.\r\n");
					btnStopPing.Enabled = false;
					btnStartPing.Enabled = true;
					txtPingLog.Cursor = Cursors.IBeam;
				}
			}
		}

		/// <summary>
		/// User wants the ping loop to stop
		/// Stop the timer, enable button for start, disable button for stop
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnStopPing_Click (object sender, EventArgs e)
		{
			pingTimer.Stop();
			txtPingLog.AppendText("Pingloop stopped by user\r\n" + pingsmade + " pings done.\r\n");
			btnStopPing.Enabled = false;
			btnStartPing.Enabled = true;
			txtPingLog.Cursor = Cursors.IBeam;
		}

		/// <summary>
		/// Save the pinglog to a textfile
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnSaveLog_Click (object sender, EventArgs e)
		{
			string text = string.Format("Ping settings:\r\nAddress: {0}\r\nPing timeout: {1}\r\nTTL: {2}\r\nPing buffer: {3}\r\nPing fragmentation: {4}\r\n\r\nPing replies:\r\n{5}", txtAddress.Text, timeout, pOptions.Ttl, BitConverter.ToString(pingbuffer), checkboxDontFragment.Checked ? "Dontfragment" : "Fragmented", txtPingLog.Text);

			File.WriteAllText(@"H:\Pinglog.txt", text);
			MessageBox.Show(@"H:\Pinglog.txt saved", "");
		}

		/// <summary>
		/// Start the pinging process
		/// If the given adress is DNS, IP-adress is resolved
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnStartPing_Click (object sender, EventArgs e)
		{
			ping = true;
			if (ping)
			{
				try
				{
					IPHostEntry hostInfo = Dns.GetHostEntry(txtAddress.Text);
					IPAddress adress;
					setPingOptions();

					pingsmade = 0;
					if (IPAddress.TryParse(txtAddress.Text, out adress))
					{
						txtPingLog.AppendText("Starts pinging " + txtAddress.Text + " (starttime " + DateTime.Now + ")\r\n");
						pingTimer.Start();
					} else
					{
						txtPingLog.AppendText("Starts pinging " + txtAddress.Text + " at IP: " + hostInfo.AddressList[hostInfo.AddressList.Length - 1] + " (starttime " + DateTime.Now + ")\r\n");
						pingTimer.Start();
					}
					btnStartPing.Enabled = false;
					btnStopPing.Enabled = true;
					txtPingLog.Cursor = Cursors.WaitCursor;
				} catch (SocketException se)
				{
					txtPingLog.AppendText("************************\r\nError:\r\n" + se.Message + "\r\n************************\r\n");
				}
			}
		}

		/// <summary>
		/// Set all options for the ping.
		/// If textbox is empty, or the option not enabled, set a default value
		/// </summary>
		void setPingOptions ()
		{
			pOptions = new PingOptions();
			pOptions.DontFragment = checkboxDontFragment.Checked;

			if (checkboxTTL.Checked)
			{
				if (txtTTL.Text.Length == 0)
					pOptions.Ttl = defaults.TTL;
				else
				{
					try
					{
						pOptions.Ttl = int.Parse(txtTTL.Text);
					} catch (FormatException)
					{
						ping = false;
						MessageBox.Show("Data for TTL is not a number", "TTL parse error");
						ActiveControl = txtTTL;
						return;
					}
				}
			} else
			{
				pOptions.Ttl = defaults.TTL;
			}
			if (checkboxLoops.Checked)
			{
				if (txtNumPings.Text.Length == 0)
					numberOfPings = defaults.NumberOfPings;
				else
				{
					try
					{
						numberOfPings = int.Parse(txtNumPings.Text);
					} catch (FormatException)
					{
						ping = false;
						MessageBox.Show("Data for number of pings is not a number", "Pingloop parse error");
						ActiveControl = txtNumPings;
						return;
					}
				}
			} else
			{
				numberOfPings = defaults.NumberOfPings;
			}
			if (checkboxBuffer.Checked)
			{
				pingbuffer = txtBuffer.Text.Length == 0 ? defaults.PingBuffer : Encoding.ASCII.GetBytes(txtBuffer.Text);
			} else
			{
				pingbuffer = defaults.PingBuffer;
			}
			if (checkboxTimeout.Checked)
			{
				if (txtTimeout.Text.Length == 0)
					timeout = defaults.Timeout;
				else
				{
					try
					{
						timeout = int.Parse(txtTimeout.Text);
					} catch (FormatException)
					{
						ping = false;
						MessageBox.Show("Data for timeout is not a number", "Timeout parse error");
						ActiveControl = txtTimeout;
						return;
					}
				}
			} else
			{
				timeout = defaults.Timeout;
			}
		}

		/// <summary>
		/// If checkbox for timeout is checked, enable textbox
		/// Otherwise disable
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void checkboxTimeout_CheckedChanged (object sender, EventArgs e)
		{
			txtTimeout.Enabled = checkboxTimeout.Checked;
		}

		/// <summary>
		/// If checkbox for TTL is checked, enable textbox
		/// Otherwise disable
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void checkboxTTL_CheckedChanged (object sender, EventArgs e)
		{
			txtTTL.Enabled = checkboxTTL.Checked;
		}

		/// <summary>
		/// If checkbox for buffer is checked, enable textbox
		/// Otherwise disable
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void checkboxBuffer_CheckedChanged (object sender, EventArgs e)
		{
			txtBuffer.Enabled = checkboxBuffer.Checked;
		}

		/// <summary>
		/// If checkbox for loops is checked, enable textbox
		/// Otherwise disable
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void checkboxLoops_CheckedChanged (object sender, EventArgs e)
		{
			txtNumPings.Enabled = checkboxLoops.Checked;
		}

		/// <summary>
		/// Shows scrollbars of log only if necessary
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtPingLog_TextChanged (object sender, EventArgs e)
		{
			bool busy = false;
			if (busy)
				return;  
			busy = true;
			
			TextBox tb = sender as TextBox;  
			Size tS = TextRenderer.MeasureText(tb.Text, tb.Font);  
			bool Hsb = tb.ClientSize.Height < tS.Height + Convert.ToInt32(tb.Font.Size);  
			bool Vsb = tb.ClientSize.Width < tS.Width;  
 
			if (Hsb && Vsb)
				tb.ScrollBars = ScrollBars.Both;
			else if (!Hsb && !Vsb)
				tb.ScrollBars = ScrollBars.None;
			else if (Hsb && !Vsb)
				tb.ScrollBars = ScrollBars.Vertical;
			else if (!Hsb && Vsb)
				tb.ScrollBars = ScrollBars.Horizontal;  
 
			sender = tb as object;  
			busy = false;
		}

		/// <summary>
		/// Eventhandler for showing/hiding the groupbox for pingsettings
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void checkboxSettings_CheckedChanged (object sender, EventArgs e)
		{
			if (checkboxSettings.Checked)
			{
				groupboxSettings.Show();
				txtPingLog.Size = new Size(448, 475);
				txtPingLog.Location = new Point(1, 138);
			} else
			{
				groupboxSettings.Hide();
				txtPingLog.Size = new Size(448, 559);
				txtPingLog.Location = new Point(1, 54);
			}
		}
	}

	public class DefaultOptions
	{
		public int TTL { get { return 128; } }
		public int Timeout { get { return 4000; } }
		public int NumberOfPings { get { return 1; } }
		public byte[] PingBuffer { get { return pingbuffer; } }
		byte[] pingbuffer = {
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		};
	}
}
