using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace PingSnurra
{
	public partial class MainForm : Form
	{
		Ping pinger = new Ping();
		PingReply prep;
		Timer t;
		List<string[]> badpackets = new List<string[]>();
		public MainForm()
		{
			InitializeComponent();
			t = new Timer();
			t.Interval = 1000;
			t.Tick += TimerCallback;
			Text = "PingSnurra version " + System.Reflection.Assembly.GetExecutingAssembly()
				.GetName().Version;
		}

		void TimerCallback (object sender, EventArgs e)
		{
			prep = pinger.Send(txtAddress.Text);
			switch (prep.Status)
			{
				case IPStatus.TimedOut:
					txtPingLog.AppendText("Pingrequest timed out. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.Success:
					txtPingLog.AppendText("Roundtriptime: " + prep.RoundtripTime + " ms" + "\r\n");
					break;
				case IPStatus.TtlExpired:
				case IPStatus.TimeExceeded:
					txtPingLog.AppendText("The ICMP echo request failed because its Time to Live (TTL) value reached zero, causing the forwarding node (router or gateway) to discard the packet. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.DestinationHostUnreachable:
					txtPingLog.AppendText("The ICMP echo request failed because the destination computer is not reachable. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.BadDestination:
					txtPingLog.AppendText("The ICMP echo request failed because the destination IP address cannot receive ICMP echo requests or should never appear in the destination address field of any IP datagram. For example, calling Send and specifying IP address '000.0.0.0' returns this status. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.BadHeader:
					txtPingLog.AppendText("The ICMP echo request failed because the header is invalid. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.BadOption:
					txtPingLog.AppendText("The ICMP echo request failed because it contains an invalid option. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.BadRoute:
					txtPingLog.AppendText("The ICMP echo request failed because there is no valid route between the source and destination computers. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.DestinationNetworkUnreachable:
					txtPingLog.AppendText("The ICMP echo request failed because the network that contains the destination computer is not reachable. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.DestinationPortUnreachable:
					txtPingLog.AppendText("The ICMP echo request failed because the port on the destination computer is not available. (time " + DateTime.Now + ")\r\n");
					break;
				case (IPStatus) 11004:
					var host = Dns.GetHostEntry(txtAddress.Text);
					var ip = host.AddressList[host.AddressList.Length - 1];
					if (ip.AddressFamily == AddressFamily.InterNetwork)
						txtPingLog.AppendText("The ICMP echo request failed because the destination computer that is specified in an ICMP echo message is not reachable, because it does not support the packet's protocol. This value applies only to IPv4. This value is described in IETF RFC 1812 as Communication Administratively Prohibited. (time " + DateTime.Now + ")\r\n");
					else
						txtPingLog.AppendText("The ICMPv6 echo request failed because contact with the destination computer is administratively prohibited. This value applies only to IPv6. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.DestinationScopeMismatch:
					txtPingLog.AppendText("The ICMP echo request failed because the source address and destination address that are specified in an ICMP echo message are not in the same scope. This is typically caused by a router forwarding a packet using an interface that is outside the scope of the source address. Address scopes (link-local, site-local, and global scope) determine where on the network an address is valid. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.DestinationUnreachable:
					txtPingLog.AppendText("The ICMP echo request failed because the destination computer that is specified in an ICMP echo message is not reachable; the exact cause of problem is unknown. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.HardwareError:
					txtPingLog.AppendText("The ICMP echo request failed because of a hardware error. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.IcmpError:
					txtPingLog.AppendText("The ICMP echo request failed because of an ICMP protocol error. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.NoResources:
					txtPingLog.AppendText("The ICMP echo request failed because of insufficient network resources. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.PacketTooBig:
					txtPingLog.AppendText("The ICMP echo request failed because the packet containing the request is larger than the maximum transmission unit (MTU) of a node (router or gateway) located between the source and destination. The MTU defines the maximum size of a transmittable packet. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.ParameterProblem:
					txtPingLog.AppendText("The ICMP echo request failed because a node (router or gateway) encountered problems while processing the packet header. This is the status if, for example, the header contains invalid field data or an unrecognized option. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.SourceQuench:
					txtPingLog.AppendText("The ICMP echo request failed because the packet was discarded. This occurs when the source computer's output queue has insufficient storage space, or when packets arrive at the destination too quickly to be processed. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.TtlReassemblyTimeExceeded:
					txtPingLog.AppendText("The ICMP echo request failed because the packet was divided into fragments for transmission and all of the fragments were not received within the time allotted for reassembly. RFC 2460 (available at www.ietf.org) specifies 60 seconds as the time limit within which all packet fragments must be received. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.Unknown:
					txtPingLog.AppendText("The ICMP echo request failed for an unknown reason. (time " + DateTime.Now + ")\r\n");
					break;
				case IPStatus.UnrecognizedNextHeader:
					txtPingLog.AppendText("The ICMP echo request failed because the Next Header field does not contain a recognized value. The Next Header field indicates the extension header type (if present) or the protocol above the IP layer, for example, TCP or UDP. (time " + DateTime.Now + ")\r\n");
					break;
			}
		}
		void BtnStopPingClick (object sender, EventArgs e)
		{
			t.Stop();
			txtPingLog.AppendText("Pingloop stopped by user\r\n");
		}
		void BtnSaveLogClick (object sender, EventArgs e)
		{
			File.WriteAllText(@"H:\Pinglog.txt", txtPingLog.Text);
			MessageBox.Show(@"H:\Pinglog.txt saved", "");
		}
		void BtnStartPingClick (object sender, EventArgs e)
		{
			IPAddress adress;
			IPHostEntry hostInfo = Dns.GetHostEntry(txtAddress.Text);


			if (IPAddress.TryParse(txtAddress.Text, out adress))
			{
				txtPingLog.AppendText("Starts pinging " + txtAddress.Text + " (starttime " + DateTime.Now + ")\r\n");
				t.Start();
			} else
			{
				txtPingLog.AppendText("Starts pinging " + txtAddress.Text + " at IP: " + hostInfo.AddressList[hostInfo.AddressList.Length - 1] + " (starttime " + DateTime.Now + ")\r\n");
				t.Start();
			}
		}
	}
}
