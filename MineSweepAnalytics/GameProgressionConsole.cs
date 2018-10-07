/*
 * Project: MineSweep 
 * 
 * File: Form1.cs
 *
 * Form for the Minesweeper Tester Program
 * 
 * Copyright © 2004 Ronald M. Zerby
 *
 * All rights reserved.
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License. 
 *   
 */


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using MindSweep;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Activation;
using System.Threading;
using System.IO;
using System.Diagnostics;


namespace MineSweep
{
    /// <summary>
    /// Summary description for GameProgressionConsole Form.
    /// </summary>
    public class GameProgressionConsole : System.Windows.Forms.Form
	{
		ArrayList TBoxes;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox CellsTotBox;
		private System.Windows.Forms.TextBox BombsTotBox;
		private System.Windows.Forms.TextBox RemainingBox;
		private System.Windows.Forms.TextBox WinsBox;
		private System.Windows.Forms.TextBox LossesBox;
		private System.Windows.Forms.Label State;
		private System.Windows.Forms.TextBox StateBox;
		public System.Windows.Forms.TextBox StatusBox;
		public System.Windows.Forms.TextBox SubStatusBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox AutoUnvBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label10;
		public System.Windows.Forms.TextBox PlayerStatusBox;
		private System.Windows.Forms.Label label11;
		public System.Windows.Forms.TextBox PlayerSubStatusBox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox PlayerPlaysBox;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox PlayerBombsBox;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox PlayerNeutralizedCellsBox;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox PlayerGuessesBox;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox PlayerNeutoBombsBox;
		private System.Windows.Forms.TextBox PortNbrBox;
		private System.Windows.Forms.Label label9;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GameProgressionConsole()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			TBoxes = new ArrayList();
			TBoxes.Add(StatusBox);
			TBoxes.Add(SubStatusBox);
			TBoxes.Add(CellsTotBox);
			TBoxes.Add(BombsTotBox);
			TBoxes.Add(RemainingBox);
			TBoxes.Add(WinsBox);
			TBoxes.Add(LossesBox);
			TBoxes.Add(StateBox);
			TBoxes.Add(AutoUnvBox);
			TBoxes.Add(PlayerStatusBox);
			TBoxes.Add(PlayerSubStatusBox);
			TBoxes.Add(PlayerPlaysBox);
			TBoxes.Add(PlayerBombsBox);
			TBoxes.Add(PlayerNeutralizedCellsBox);
			TBoxes.Add(PlayerGuessesBox);
			TBoxes.Add(PlayerNeutoBombsBox);

			Trace.Listeners.Add(new MyTraceLisiner(TBoxes));

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.StatusBox = new System.Windows.Forms.TextBox();
            this.SubStatusBox = new System.Windows.Forms.TextBox();
            this.CellsTotBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BombsTotBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RemainingBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.WinsBox = new System.Windows.Forms.TextBox();
            this.LossesBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PlayerNeutoBombsBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.PlayerGuessesBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.PlayerNeutralizedCellsBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.PlayerBombsBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.PlayerPlaysBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.PlayerSubStatusBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.PlayerStatusBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.State = new System.Windows.Forms.Label();
            this.StateBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AutoUnvBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PortNbrBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StatusBox
            // 
            this.StatusBox.Location = new System.Drawing.Point(20, 250);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.ReadOnly = true;
            this.StatusBox.Size = new System.Drawing.Size(327, 20);
            this.StatusBox.TabIndex = 1;
            // 
            // SubStatusBox
            // 
            this.SubStatusBox.Location = new System.Drawing.Point(20, 298);
            this.SubStatusBox.Name = "SubStatusBox";
            this.SubStatusBox.ReadOnly = true;
            this.SubStatusBox.Size = new System.Drawing.Size(333, 20);
            this.SubStatusBox.TabIndex = 2;
            // 
            // CellsTotBox
            // 
            this.CellsTotBox.Location = new System.Drawing.Point(13, 55);
            this.CellsTotBox.Name = "CellsTotBox";
            this.CellsTotBox.ReadOnly = true;
            this.CellsTotBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CellsTotBox.Size = new System.Drawing.Size(84, 20);
            this.CellsTotBox.TabIndex = 3;
            this.CellsTotBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Cells";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Total Bombs";
            // 
            // BombsTotBox
            // 
            this.BombsTotBox.Location = new System.Drawing.Point(13, 111);
            this.BombsTotBox.Name = "BombsTotBox";
            this.BombsTotBox.ReadOnly = true;
            this.BombsTotBox.Size = new System.Drawing.Size(84, 20);
            this.BombsTotBox.TabIndex = 6;
            this.BombsTotBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(133, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Remaining Cells";
            // 
            // RemainingBox
            // 
            this.RemainingBox.Location = new System.Drawing.Point(133, 55);
            this.RemainingBox.Name = "RemainingBox";
            this.RemainingBox.ReadOnly = true;
            this.RemainingBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RemainingBox.Size = new System.Drawing.Size(87, 20);
            this.RemainingBox.TabIndex = 8;
            this.RemainingBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(73, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Wins";
            // 
            // WinsBox
            // 
            this.WinsBox.Location = new System.Drawing.Point(73, 180);
            this.WinsBox.Name = "WinsBox";
            this.WinsBox.ReadOnly = true;
            this.WinsBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WinsBox.Size = new System.Drawing.Size(84, 20);
            this.WinsBox.TabIndex = 10;
            this.WinsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LossesBox
            // 
            this.LossesBox.Location = new System.Drawing.Point(207, 180);
            this.LossesBox.Name = "LossesBox";
            this.LossesBox.ReadOnly = true;
            this.LossesBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LossesBox.Size = new System.Drawing.Size(83, 20);
            this.LossesBox.TabIndex = 11;
            this.LossesBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(207, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Losses";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PlayerNeutoBombsBox);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.PlayerGuessesBox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.PlayerNeutralizedCellsBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.PlayerBombsBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.PlayerPlaysBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.PlayerSubStatusBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.PlayerStatusBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(447, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 340);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player";
            // 
            // PlayerNeutoBombsBox
            // 
            this.PlayerNeutoBombsBox.Location = new System.Drawing.Point(20, 166);
            this.PlayerNeutoBombsBox.Name = "PlayerNeutoBombsBox";
            this.PlayerNeutoBombsBox.ReadOnly = true;
            this.PlayerNeutoBombsBox.Size = new System.Drawing.Size(83, 20);
            this.PlayerNeutoBombsBox.TabIndex = 30;
            this.PlayerNeutoBombsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(20, 146);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 20);
            this.label16.TabIndex = 29;
            this.label16.Text = "Neutralized Bombs";
            // 
            // PlayerGuessesBox
            // 
            this.PlayerGuessesBox.Location = new System.Drawing.Point(160, 111);
            this.PlayerGuessesBox.Name = "PlayerGuessesBox";
            this.PlayerGuessesBox.ReadOnly = true;
            this.PlayerGuessesBox.Size = new System.Drawing.Size(83, 20);
            this.PlayerGuessesBox.TabIndex = 28;
            this.PlayerGuessesBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(160, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 14);
            this.label15.TabIndex = 27;
            this.label15.Text = "Total Guesses";
            // 
            // PlayerNeutralizedCellsBox
            // 
            this.PlayerNeutralizedCellsBox.Location = new System.Drawing.Point(160, 55);
            this.PlayerNeutralizedCellsBox.Name = "PlayerNeutralizedCellsBox";
            this.PlayerNeutralizedCellsBox.ReadOnly = true;
            this.PlayerNeutralizedCellsBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PlayerNeutralizedCellsBox.Size = new System.Drawing.Size(87, 20);
            this.PlayerNeutralizedCellsBox.TabIndex = 26;
            this.PlayerNeutralizedCellsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(160, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 20);
            this.label14.TabIndex = 25;
            this.label14.Text = "Neutralized Cells";
            // 
            // PlayerBombsBox
            // 
            this.PlayerBombsBox.Location = new System.Drawing.Point(20, 111);
            this.PlayerBombsBox.Name = "PlayerBombsBox";
            this.PlayerBombsBox.ReadOnly = true;
            this.PlayerBombsBox.Size = new System.Drawing.Size(83, 20);
            this.PlayerBombsBox.TabIndex = 24;
            this.PlayerBombsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(20, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 14);
            this.label13.TabIndex = 23;
            this.label13.Text = "Total Bombs";
            // 
            // PlayerPlaysBox
            // 
            this.PlayerPlaysBox.Location = new System.Drawing.Point(20, 55);
            this.PlayerPlaysBox.Name = "PlayerPlaysBox";
            this.PlayerPlaysBox.ReadOnly = true;
            this.PlayerPlaysBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PlayerPlaysBox.Size = new System.Drawing.Size(83, 20);
            this.PlayerPlaysBox.TabIndex = 22;
            this.PlayerPlaysBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(20, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "Plays";
            // 
            // PlayerSubStatusBox
            // 
            this.PlayerSubStatusBox.Location = new System.Drawing.Point(13, 298);
            this.PlayerSubStatusBox.Name = "PlayerSubStatusBox";
            this.PlayerSubStatusBox.ReadOnly = true;
            this.PlayerSubStatusBox.Size = new System.Drawing.Size(367, 20);
            this.PlayerSubStatusBox.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(20, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Sub Status";
            // 
            // PlayerStatusBox
            // 
            this.PlayerStatusBox.Location = new System.Drawing.Point(13, 250);
            this.PlayerStatusBox.Name = "PlayerStatusBox";
            this.PlayerStatusBox.ReadOnly = true;
            this.PlayerStatusBox.Size = new System.Drawing.Size(367, 20);
            this.PlayerStatusBox.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(20, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Status";
            // 
            // State
            // 
            this.State.Location = new System.Drawing.Point(133, 90);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(84, 20);
            this.State.TabIndex = 14;
            this.State.Text = "State";
            // 
            // StateBox
            // 
            this.StateBox.Location = new System.Drawing.Point(133, 111);
            this.StateBox.Name = "StateBox";
            this.StateBox.ReadOnly = true;
            this.StateBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StateBox.Size = new System.Drawing.Size(84, 20);
            this.StateBox.TabIndex = 15;
            this.StateBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Status";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(20, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Sub Status";
            // 
            // AutoUnvBox
            // 
            this.AutoUnvBox.Location = new System.Drawing.Point(273, 55);
            this.AutoUnvBox.Name = "AutoUnvBox";
            this.AutoUnvBox.ReadOnly = true;
            this.AutoUnvBox.Size = new System.Drawing.Size(84, 20);
            this.AutoUnvBox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(273, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Neutral Cells";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.CellsTotBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.BombsTotBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.StatusBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.SubStatusBox);
            this.groupBox2.Controls.Add(this.State);
            this.groupBox2.Controls.Add(this.StateBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.RemainingBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.AutoUnvBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.WinsBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.LossesBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 340);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Game";
            // 
            // PortNbrBox
            // 
            this.PortNbrBox.Location = new System.Drawing.Point(213, 367);
            this.PortNbrBox.Name = "PortNbrBox";
            this.PortNbrBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PortNbrBox.Size = new System.Drawing.Size(84, 20);
            this.PortNbrBox.TabIndex = 21;
            this.PortNbrBox.Text = "5411";
            this.PortNbrBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(180, 367);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Port";
            // 
            // GameProgressionConsole
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1048, 472);
            this.Controls.Add(this.PortNbrBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Name = "GameProgressionConsole";
            this.Text = "Game Progression Console";
            this.Load += new System.EventHandler(this.GameProgressionConsole_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new GameProgressionConsole());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			new MindSweepChannel(int.Parse(PortNbrBox.Text)); // MindSweepChannel1 open for bizness.
			button1.Enabled = false;
		}

        private void GameProgressionConsole_Load(object sender, EventArgs e)
        {

        }
    }

    /**
	 *  MyTraceLisiner forwards traceing messages from the Dll to the textbox 
	 */

    class MyTraceLisiner : TraceListener
	{
		System.IO.MemoryStream ms;
		System.IO.StreamWriter swr;
		ArrayList TBoxes;

		public MyTraceLisiner(ArrayList TBA) : base()
		{
			ms = new System.IO.MemoryStream(1024);
			swr = new System.IO.StreamWriter(ms);
			TBoxes = TBA;
		}

		public override void Write(string msg)
		{
			foreach(System.Windows.Forms.TextBox textbox in TBoxes)
			{
				String Name = textbox.Name;
				if (msg.Split(':')[0].CompareTo(Name) == 0)
				{
					textbox.Text = msg.Split(':')[1].ToString();
					textbox.Invalidate();
				}
			}
		}

		public override void WriteLine(string msg)
		{
			foreach(System.Windows.Forms.TextBox textbox in TBoxes)
			{
				String Name = textbox.Name;
				if (msg.Split(':')[0].CompareTo(Name) == 0)
				{
                    //textbox.Text = msg.Split(':')[1].ToString();
                    textbox.Invoke(new Action(() =>
                    {
                        textbox.Text = msg.Split(':')[1].ToString();
                    }));
                    textbox.Invalidate();
				}
			}
		}
	}

}
