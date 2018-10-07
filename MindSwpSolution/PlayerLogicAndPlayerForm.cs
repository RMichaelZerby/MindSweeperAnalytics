/*
 *
 * Project: MindSwpSolutionLogic
 * 
 * File: PlayerLogicAndPlayerForm.cs
 *
 * The solution to solve the puzzle of Minesweeper. 
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
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;



namespace MindSwpSolution
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class PlayerLogicAndPlayerForm : System.Windows.Forms.Form
	{
		private player player1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox URLBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Iterations;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox YStep;
		private System.Windows.Forms.TextBox XStep;
		private System.Windows.Forms.TextBox YOrigan;
		private System.Windows.Forms.TextBox XOrigan;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox RBombs;
		private System.Windows.Forms.TextBox Status;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// The form that I am using as a base of my application
		/// </summary>
		public PlayerLogicAndPlayerForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ArrayList TBoxes = new ArrayList();
			TBoxes.Add(Status);

			Trace.Listeners.Add(new MyTraceListener(TBoxes));

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
			this.button2 = new System.Windows.Forms.Button();
			this.Status = new System.Windows.Forms.TextBox();
			this.URLBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Iterations = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.YStep = new System.Windows.Forms.TextBox();
			this.XStep = new System.Windows.Forms.TextBox();
			this.YOrigan = new System.Windows.Forms.TextBox();
			this.XOrigan = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.RBombs = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(104, 408);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "Start";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(104, 376);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "Play";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Status
			// 
			this.Status.Location = new System.Drawing.Point(24, 520);
			this.Status.Name = "Status";
			this.Status.Size = new System.Drawing.Size(240, 22);
			this.Status.TabIndex = 2;
			this.Status.Text = "textBox1";
			// 
			// URLBox
			// 
			this.URLBox.Location = new System.Drawing.Point(32, 328);
			this.URLBox.Name = "URLBox";
			this.URLBox.Size = new System.Drawing.Size(240, 22);
			this.URLBox.TabIndex = 3;
			this.URLBox.Text = "tcp://localhost:5411/MindSweep";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 304);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "URL OF SERVICE";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 496);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Status";
			// 
			// Iterations
			// 
			this.Iterations.Location = new System.Drawing.Point(16, 40);
			this.Iterations.MaxLength = 4;
			this.Iterations.Name = "Iterations";
			this.Iterations.Size = new System.Drawing.Size(72, 22);
			this.Iterations.TabIndex = 6;
			this.Iterations.Text = "1";
			this.Iterations.WordWrap = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Number of Iterations";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "X Origan";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 168);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "Y Origan";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(152, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "X Step";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(152, 168);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 23);
			this.label7.TabIndex = 12;
			this.label7.Text = "Y Step";
			// 
			// YStep
			// 
			this.YStep.Location = new System.Drawing.Point(152, 184);
			this.YStep.MaxLength = 4;
			this.YStep.Name = "YStep";
			this.YStep.Size = new System.Drawing.Size(72, 22);
			this.YStep.TabIndex = 13;
			this.YStep.Text = "0";
			this.YStep.WordWrap = false;
			// 
			// XStep
			// 
			this.XStep.Location = new System.Drawing.Point(152, 136);
			this.XStep.MaxLength = 4;
			this.XStep.Name = "XStep";
			this.XStep.Size = new System.Drawing.Size(72, 22);
			this.XStep.TabIndex = 14;
			this.XStep.Text = "0";
			this.XStep.WordWrap = false;
			// 
			// YOrigan
			// 
			this.YOrigan.Location = new System.Drawing.Point(16, 184);
			this.YOrigan.MaxLength = 4;
			this.YOrigan.Name = "YOrigan";
			this.YOrigan.Size = new System.Drawing.Size(72, 22);
			this.YOrigan.TabIndex = 15;
			this.YOrigan.Text = "10";
			this.YOrigan.WordWrap = false;
			// 
			// XOrigan
			// 
			this.XOrigan.Location = new System.Drawing.Point(16, 136);
			this.XOrigan.MaxLength = 4;
			this.XOrigan.Name = "XOrigan";
			this.XOrigan.Size = new System.Drawing.Size(72, 22);
			this.XOrigan.TabIndex = 16;
			this.XOrigan.Text = "10";
			this.XOrigan.WordWrap = false;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 224);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 23);
			this.label8.TabIndex = 17;
			this.label8.Text = "Bomb Ratio";
			// 
			// RBombs
			// 
			this.RBombs.Location = new System.Drawing.Point(16, 248);
			this.RBombs.MaxLength = 2;
			this.RBombs.Name = "RBombs";
			this.RBombs.Size = new System.Drawing.Size(72, 22);
			this.RBombs.TabIndex = 18;
			this.RBombs.Text = "10";
			this.RBombs.WordWrap = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(320, 552);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.RBombs,
																		  this.label8,
																		  this.XOrigan,
																		  this.YOrigan,
																		  this.XStep,
																		  this.YStep,
																		  this.label7,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.Iterations,
																		  this.label2,
																		  this.label1,
																		  this.URLBox,
																		  this.Status,
																		  this.button2,
																		  this.button1});
			this.Name = "GameControlsForm";
			this.Text = "Game Controls Form";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new PlayerLogicAndPlayerForm());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			player1 = new player();

			button1.Enabled = false;
			button2.Enabled = true;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			button2.Enabled = false;

			Dem.iTotRows = int.Parse(XOrigan.Text);
			Dem.iTotCols = int.Parse(YOrigan.Text);
			int xStep = int.Parse(XStep.Text);
			int yStep = int.Parse(YStep.Text);
			int iter = int.Parse(Iterations.Text);
			int rbombs = int.Parse(RBombs.Text);


			for(int i=0; i++<iter; )
			{
				Dem.iTotBombs = (int)((Dem.iTotCols*Dem.iTotRows)*((1.0*rbombs)/100)); 
				player1.play();
				Dem.iTotCols+=xStep;
				Dem.iTotRows+=yStep;
			}

			button2.Enabled = true;
		}

		/// <summary>
		/// Get the user defined URL
		/// </summary>
		/// <returns></returns>
		public String getURL()
		{
			return URLBox.Text;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

	}

	/// <summary>
	/// Tracing Display Targets
	/// each string represents the name of a control on   
	/// the display screen where the message is sent
	/// </summary>
	public class TrcDf
	{
		/// <summary>
		/// General status messages
		/// </summary>
		internal static string Status = "PlayerStatusBox:";
		/// <summary>
		/// General sub-status message
		/// </summary>
		internal static string SubStatus = "PlayerSubStatusBox:";
		/// <summary>
		/// The number of plays we have made
		/// </summary>
		internal static string Plays = "PlayerPlaysBox:"; 
		/// <summary>
		/// Number of neutralized cells 
		/// </summary>
		internal static string NeutralizedCells = "PlayerNeutralizedCellsBox:"; 
		/// <summary>
		/// Number of bombs the player has found
		/// </summary>
		internal static string BombsTot = "PlayerBombsBox:"; 
		/// <summary>
		/// Number of guesses the player has made.
		/// </summary>
		internal static string Guesses = "PlayerGuessesBox:";  
		/// <summary>
		/// Number of neutralized bombs the player has discovered
		/// </summary>
		internal static string NeutralizedBombs = "PlayerNeutoBombsBox:"; 
	}

	/// <summary>
	/// Internal variable store
	/// </summary>
	class Dem
	{
		/// <summary>
		/// The total number of rows we are using
		/// </summary>
		internal static int iTotRows = 100; 
		/// <summary>
		/// The total number of columns 
		/// </summary>
		internal static int iTotCols = 100;
		/// <summary>
		/// The total number of bombs 
		/// </summary>
		internal static int iTotBombs = 1000; 
		/// <summary>
		/// List of Shadow Bombs
		/// </summary>
		internal static ArrayList arrShadowBombs = new ArrayList();
		/// <summary>
		/// The URL to use
		/// </summary>
		internal static String URL = "tcp://localhost:5411/MindSweep";
		/// <summary>
		/// The Current game as a number (debugging)
		/// </summary>
		internal static int iGameID = 0; 
		/// <summary>
		/// Tracing Level 1 Light
		/// </summary>
		internal static BooleanSwitch bTraceLight = new BooleanSwitch("TraceLight", "MineSwpSolution TraceLight");
		/// <summary>
		/// Tracing Level 2 Medium
		/// </summary>
		internal static BooleanSwitch bTraceMedium = new BooleanSwitch("TraceMedium", "MineSwpSolution TraceMedium");
		/// <summary>
		/// Tracing Level 3 Deep
		/// </summary>
		internal static BooleanSwitch bTraceDeep = new BooleanSwitch("TraceDeep", "MineSwpSolution TraceDeep");
		/// <summary>
		/// Tracing Any Sure Things
		/// </summary>
		internal static BooleanSwitch bAnySurThing = new BooleanSwitch("AnySureThing", "MineSwpSolution Any Sure Thing");
		/// <summary>
		/// Tracing Any Sure Things Extra
		/// </summary>
		internal static BooleanSwitch bAnySureThingExt = new BooleanSwitch("AnySureThingExtra", "MineSwpSolution Any Sure Thing Extra");
		/// <summary>
		/// Composite Input File out puts
		/// </summary>
		internal static BooleanSwitch bCompInp  = new BooleanSwitch("CompositeInput", "MineSwpSolution");
		/// <summary>
		/// A way to exclude the secondary measure of 'anySureThing' from the solution 
		/// </summary>
		internal static BooleanSwitch bExcludeAnySureThing  = new BooleanSwitch("ExcludeAnySureThing", "MineSwpSolution");
		/// <summary>
		/// Used to track when I guess vs a sure thing
		/// </summary>
		internal static bool bSureThing = false;

		internal static Game gObj = null;


	}

    /// <summary>
    /// This is the player and is where the logic for playing the MineSweeper game is located
    /// ( MineSweeper P v.s. NP? in action )
    /// </summary>
    class player
	{
		/// <summary>
		/// The tcp/ip channel to the game
		/// </summary>
		TcpClientChannel tcpClientchannel = null; 
		/// <summary>
		/// The current game object
		/// </summary>
		Game gameObj = null;
		/// <summary>
		/// The state of the current game.
		/// </summary>
		State lState = State.Limbo; 
		/// <summary>
		/// The number of neutralized bombs
		/// </summary>
		int nbrNeutralizedBombs; 
		/// <summary>
		/// The number of uncovered squares
		/// </summary>
		int nbrUncovered; 
		/// <summary>
		/// The number of neutralized cells
		/// </summary>
		int nbrNeutralized; 
		/// <summary>
		/// The number of cells uncovered by us selecting
		/// </summary>
		int nbrOfSelects; 
		/// <summary>
		/// The number of guesses we have made
		/// </summary>
		internal static 
			int nbrOfGuesses; 
		/// <summary>
		/// The number of times Sure Thing was successful;
		/// </summary>
		int nbrOfSureThings; 
		/// <summary>
		/// The number of cells uncovered as a sure thing.
		/// </summary>
		int cntOfSureThings; 

		/// <summary>
		/// Array of string of the current guesses being made (debugging)
		/// </summary>
		ArrayList lastGuesses = new ArrayList(); 
		/// <summary>
		/// Array of string of all the previous guesses made (debugging)
		/// </summary>
		ArrayList myGuesses = new ArrayList();

		/// <summary>
		/// Constructor that connects to the game interface, seen as the gameObj
		/// </summary>
		public player()
		{
			tcpClientchannel = new  TcpClientChannel();
			ChannelServices.RegisterChannel(tcpClientchannel, true);
		}

		/// <summary>
		/// The logic of playing the game
		/// </summary>
		/// <returns>true if we won the game</returns>
		public bool play()
		{
			Dem.iGameID++;
			Stream myFile = null;
			TextWriterTraceListener myTextListener = null;

			if (Dem.bTraceLight.Enabled || Dem.bTraceMedium.Enabled || Dem.bTraceDeep.Enabled)
			{
				// Create a file for output 
				myFile = File.Create("C:\\minesweeper\\TraceGame"+Dem.iGameID.ToString("D4")+".txt");

				myTextListener = new 
					TextWriterTraceListener(myFile);
				Trace.Listeners.Add(myTextListener);
				System.Diagnostics.Trace.WriteLine("Game#" + Dem.iGameID + "\r\n");
			}


			lastGuesses = new ArrayList();
			myGuesses = new ArrayList();

			PlayerLogicAndPlayerForm F1 = (PlayerLogicAndPlayerForm)MindSwpSolution.PlayerLogicAndPlayerForm.ActiveForm;
			if (F1 != null)
				Dem.URL = F1.getURL();

			object[] attrs = { new UrlAttribute
								 (Dem.URL) };
			ObjectHandle handle = null;
			try 
			{
				handle = Activator.CreateInstance("MindSweep","MindSweep.Game",attrs);
			}
			catch (Exception ex)
			{
				throw (new Exception("Connection failed, check that the server is running, you are using the right URL and Port...", ex));
			}

			gameObj = (Game)handle.Unwrap();
			Dem.gObj = gameObj;

			gameObj.setStatus( TrcDf.Status + "Player is setting up the game.");
			gameObj.setStatus(TrcDf.SubStatus + "");

			nbrUncovered = 0; 
			nbrOfGuesses = 0;
			nbrNeutralized = 0;
			nbrNeutralizedBombs = 0;
			nbrOfSelects = 0;
			nbrOfSureThings = 0;
			cntOfSureThings = 0;
			Dem.arrShadowBombs = new ArrayList();

			gameObj.setStatus(TrcDf.BombsTot + Dem.arrShadowBombs.Count );
			gameObj.setStatus(TrcDf.Guesses + nbrOfGuesses );
			gameObj.setStatus(TrcDf.NeutralizedCells + this.nbrNeutralized );
			gameObj.setStatus(TrcDf.Plays + this.nbrOfSelects );

			//Player sets the size of the board and the number of bombs
			gameObj.setNumberOfColumns(Dem.iTotCols);
			gameObj.setNumberOfRows(Dem.iTotRows);

			Dem.iTotCols = gameObj.getNumberOfColumns();
			Dem.iTotRows = gameObj.getNumberOfRows();

			if (Dem.bTraceLight.Enabled)
				System.Diagnostics.Trace.Write("Total Rows " + Dem.iTotRows + "  " + " Cols " + Dem.iTotCols);

			gameObj.setStatus(TrcDf.SubStatus + "Requesting the new board");

			//If [the number of bombs are less then one]
			if (Dem.iTotBombs < 1)
				Dem.iTotBombs = 1;

			gameObj.setNumberOfBombs(Dem.iTotBombs);
			Dem.iTotBombs = gameObj.getNumberOfBombs();

			// Create our new empty cells array
			ShadowCell.shadowCellsRowCol = new ArrayList();

			gameObj.setStatus(TrcDf.SubStatus + "Setting up the internal board by Row and Column");

			// Fill in cell matrix by row and column, where all cells are covered at this point
			for(int x = 0; x<Dem.iTotCols*Dem.iTotRows; x++)
				ShadowCell.shadowCellsRowCol.Add(new ShadowCell(x));

			gameObj.setStatus(TrcDf.SubStatus + "Setting up the internal board by Column and Row");

			gameObj.setStatus(TrcDf.SubStatus + "Setting up the internal list of adjacent cells");

			// Set up the adjacent cells 
			foreach( ShadowCell sc in ShadowCell.shadowCellsRowCol ) 
				sc.hookAdjCells();

			gameObj.setStatus( TrcDf.Status + "Player is starting a new game.");
			gameObj.setStatus(TrcDf.SubStatus + "");

			// Start a new game
			gameObj.Start();

			// Measure the time it takes to play the game
			DateTime dt1 = System.DateTime.Now;

			// Pick the very first cell to uncover
			int Rv = MyRand((Dem.iTotCols*Dem.iTotRows));
			Pos guessPos = new Pos(Rv); 
			lState = gameObj.select(guessPos.GetCol(),guessPos.GetRow());
			String sTrMsg = "First guess is row " + guessPos.GetRow() + " col. " +  guessPos.GetCol() + "\r\n";
			myGuesses.Add(sTrMsg);
			nbrOfGuesses++;
			nbrOfSelects++; 
			if (Dem.bTraceLight.Enabled)
				System.Diagnostics.Trace.Write(sTrMsg);

			gameObj.setStatus(TrcDf.Plays + this.nbrOfSelects );
			gameObj.setStatus(TrcDf.Guesses + nbrOfGuesses );

			char[] ca = new char[1];

			int iNp = 0;
			// Now While we are still playing
			while (lState == State.Playing) 
			{
				if (Dem.bTraceLight.Enabled)
					System.Diagnostics.Trace.WriteLine("* * * * * * * * * * * * * * * * * P a s s " + iNp);

				iNp++;
				ArrayList shdCellsRowCol = new ArrayList(); 
				gameObj.setStatus( TrcDf.Status + "Player is getting the current state of the game.");

				// Get the current cell matrix from the games interface.
				ca = gameObj.getDisplay(); 

				gameObj.setStatus( TrcDf.Status + "Player is memorizing the current state of the game.");

				nbrUncovered = 0;
				System.Collections.IEnumerator sce = ShadowCell.shadowCellsRowCol.GetEnumerator();
				// Update the  shadow cells with their new display states from the game
				foreach( char c in ca ) 
				{
					try 
					{
						//IF: [The number of display elements exceed the shadow cells]
						if( sce.MoveNext() == false )
							throw (new ApplicationException("Logic Error: The number of display elements exceed the shadow cells"));
						// Update the shadow cells accordingly
						((ShadowCell)(sce.Current)).setDisplay(c);
						//IF: [The cell is uncovered]
						if (Char.IsDigit(c) == true)
							nbrUncovered++; 

						//IF: [the cell is in play]
						if (((ShadowCell)(sce.Current)).getState() == ShadowCell.CurState.Unknown)
						{
							//IF: [Uncovered} then [Add to the list of cells to investigate]
							if (Char.IsDigit(((ShadowCell)(sce.Current)).getDisplay()) == true) 
								shdCellsRowCol.Add(((ShadowCell)(sce.Current)));
						}
					} 
					catch( ApplicationException e ) 
					{
						throw (new ApplicationException("Exception Error: loading the shadow cells: " + e.Message));
					}
				}

				gameObj.setStatus( TrcDf.Status + "Player is locating all the uncovered cells that are still in play.");

				//IF: [There are any uncovered cells to find]
				if (shdCellsRowCol.Count > 0)
					gameObj.setStatus(TrcDf.Status + "Player is deducing the location of bombs from,");
				else
					gameObj.setStatus(TrcDf.SubStatus + "There are no uncovered cells to find.");

				ArrayList ssc = new ArrayList(); // The list of safe cells.
				// For All uncovered squares in play.
				foreach( ShadowCell usc in shdCellsRowCol)
				{
					ssc.AddRange(deduceNewBombs(usc));
					// IF: [I have won]
					if (ssc.Count > 0)
					{
						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine("I have Won");
						break; // Stop working
					}
				}

				gameObj.setStatus(TrcDf.BombsTot + Dem.arrShadowBombs.Count );
				gameObj.setStatus(TrcDf.NeutralizedCells + this.nbrNeutralized );
				gameObj.setStatus(TrcDf.NeutralizedBombs + this.nbrNeutralizedBombs );

				if (Dem.bTraceLight.Enabled)
				{
					System.Diagnostics.Trace.WriteLine("Bombs found " + Dem.arrShadowBombs.Count);
					System.Diagnostics.Trace.WriteLine("Neutralized Cells " + this.nbrNeutralized);
					System.Diagnostics.Trace.WriteLine("Neutralized Bombs " + this.nbrNeutralizedBombs);
				}

				// IF: [We have not already won]
				if (ssc.Count <= 0) 
				{
					gameObj.setStatus(TrcDf.Status + "Player is deducing the number safe cells.");
					gameObj.setStatus(TrcDf.SubStatus + "");

					// Find all the safe cells to uncover.
					ssc.AddRange(deduceSafeCells()); 
				}

				//IF: [There are any safe moves to make]
				if (ssc.Count > 0)
				{
					if (Dem.bTraceLight.Enabled)
						System.Diagnostics.Trace.WriteLine("Player has deduced that there are " + ssc.Count + " safe moves to make.");
					gameObj.setStatus(TrcDf.Status + "Player has deduced that there are " + ssc.Count + " safe moves to make.");
				}

				//IF: [There are neutralized cell to uncover]
				if (ssc.Count > 0)
				{
					// Uncover all the neutralized cells
					foreach( ShadowCell sc in ssc)
					{
						lState = gameObj.select(sc.getPos().GetCol(),sc.getPos().GetRow());
						nbrOfSelects++; // Increment for every selection we make
						//IF: [Selection is not a bomb]
						if (lState != State.Playing)
						{
							//IF: [I have won]
							if (lState == State.Won)
								break;
							throw (new ApplicationException("Logic Error: Selecting neutralized cell Row" + 
								sc.getPos().GetRow() + " Col " + sc.getPos().GetCol() ));
						}
					}
				}
				else
				{
					gameObj.setStatus(TrcDf.Status + "Player has deduced that there are no neutralized cells to find");
					gameObj.setStatus(TrcDf.SubStatus + "and will analyze the board for safe moves.");
					if (Dem.bTraceLight.Enabled)
						System.Diagnostics.Trace.WriteLine("There are no neutralized cells to find");
					//Then try to guess the best cell to uncover.
					ArrayList alSC = MyBestGuess();
					foreach(ShadowCell xSC in alSC)
					{
						lState = gameObj.select(xSC.getPos().GetCol(),xSC.getPos().GetRow());
						nbrOfSelects++; 
						if (Dem.bSureThing == false)
							sTrMsg = "Best guess is row " + xSC.getPos().GetRow() + " col. " +  xSC.getPos().GetCol();
						else 
							sTrMsg = "Sure thing is row " + xSC.getPos().GetRow() + " col. " +  xSC.getPos().GetCol();
						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine(sTrMsg + "\r\n");
						gameObj.setStatus(sTrMsg);
						gameObj.setStatus(TrcDf.SubStatus + "");
						//IF: [this was a sure thing] and [I lost]
						if (Dem.bSureThing == true && lState == State.Lost )
							throw (new ApplicationException("Logic Error: Logic error in pattern guessing!"));
					}
				}

				gameObj.setStatus(TrcDf.BombsTot + Dem.arrShadowBombs.Count );
				gameObj.setStatus(TrcDf.Guesses + nbrOfGuesses );
				gameObj.setStatus(TrcDf.NeutralizedCells + this.nbrNeutralized );
				gameObj.setStatus(TrcDf.Plays + this.nbrOfSelects );
				gameObj.setStatus(TrcDf.NeutralizedBombs + this.nbrNeutralizedBombs );

				if (Dem.bTraceLight.Enabled)
				{
					System.Diagnostics.Trace.WriteLine("Bombs found " + Dem.arrShadowBombs.Count);
					System.Diagnostics.Trace.WriteLine("Guesses made " + nbrOfGuesses);
					System.Diagnostics.Trace.WriteLine("Neutralized Cells " + this.nbrNeutralized);
					System.Diagnostics.Trace.WriteLine("Plays " + this.nbrOfSelects);
					System.Diagnostics.Trace.WriteLine("Neutralized Bombs " + this.nbrNeutralizedBombs);
					System.Diagnostics.Trace.WriteLine("Sure things " + this.cntOfSureThings);
				}

			}

			gameObj.setStatus(TrcDf.BombsTot + Dem.arrShadowBombs.Count );
			gameObj.setStatus(TrcDf.Guesses + nbrOfGuesses );
			gameObj.setStatus(TrcDf.NeutralizedCells + this.nbrNeutralized );
			gameObj.setStatus(TrcDf.Plays + this.nbrOfSelects );

			if (Dem.bTraceLight.Enabled)
			{
				System.Diagnostics.Trace.WriteLine("Bombs found " + Dem.arrShadowBombs.Count);
				System.Diagnostics.Trace.WriteLine("Guesses made " + nbrOfGuesses);
				System.Diagnostics.Trace.WriteLine("Neutralized Cells " + this.nbrNeutralized);
				System.Diagnostics.Trace.WriteLine("Plays " + this.nbrOfSelects);
				System.Diagnostics.Trace.WriteLine("Neutralized Bombs " + this.nbrNeutralizedBombs);
				System.Diagnostics.Trace.WriteLine("Sure things " + this.cntOfSureThings);
			}

			//Well how did I do? 
			switch (lState) 
			{
				case State.Lost:
					DateTime dt2 = System.DateTime.Now;
					FileStream fs;
					if (!File.Exists("C:\\minesweeper\\minesweep.txt"))
						fs = File.Create("C:\\minesweeper\\minesweep.txt");
					else
						fs = File.OpenWrite("C:\\minesweeper\\minesweep.txt");
					fs.Seek(0,SeekOrigin.End);
					StreamWriter sw = new StreamWriter( fs );
					sw.Write("\r\n\r\n" + System.DateTime.Now.ToString() + "\r\n");
					sw.Write("Game# " + Dem.iGameID + "\r\n");
					ca = gameObj.getDisplay(); 
					int nbrOfUncCells = gameObj.getNbrOfUncoveredCells();
					System.Collections.IEnumerator sce = ShadowCell.shadowCellsRowCol.GetEnumerator();
					nbrUncovered = 0;
					// Update the  shadow cells with the most current display states from the game.
					foreach( char c in ca ) 
					{
						try 
						{
							//IF: [The number of display elements exceed the shadow cells]
							if( sce.MoveNext() == false )
								throw (new ApplicationException("Logic Error: Games display cells exceed that of the shadow cells."));
							//IF: [The Cell is uncovered]
							if (Char.IsDigit(c) == true)
								nbrUncovered++; // Count the number of uncovered cells.
							// Update the shadow cells accordingly
							((ShadowCell)(sce.Current)).setDisplay(c);
						} 
						catch( ApplicationException e ) 
						{
							throw (new ApplicationException("Exception Error: lost game and updating shadowCellsRowCol " + e.Message));
						}
					}
					sce = ShadowCell.shadowCellsRowCol.GetEnumerator();
					for(int e=1; e<=Dem.iTotRows;e++)
					{
						sw.Write(e.ToString("D7") + " ");
						for(int w=0; w<Dem.iTotCols; w++)
						{
							if( sce.MoveNext() == false )
								throw (new ApplicationException("Logic Error: Games display cells exceed those of the shadow cells."));
							if (((ShadowCell)(sce.Current)).getState() == ShadowCell.CurState.Bomb)
								sw.Write("X");
							else
								sw.Write(((ShadowCell)(sce.Current)).getDisplay());
						}
						sw.Write("\r\n");
					}
					sw.Write("\r\n");
					sw.Write("Count of uncovered " + nbrUncovered + " out of " + 
						(Dem.iTotCols*Dem.iTotRows - Dem.iTotBombs) + " = " + 
						((Dem.iTotCols*Dem.iTotRows-Dem.iTotBombs)-nbrUncovered) +"\r\n");
					sw.Write("Count of bombs discovered " + Dem.arrShadowBombs.Count + 
						" out of " + Dem.iTotBombs + " = " +
						(Dem.iTotBombs-Dem.arrShadowBombs.Count)  + "\r\n\r\n");
					sw.Write("Count of guesses " + nbrOfGuesses + "\r\n");
					sw.Write("Number of Guesses that became a sure thing " + nbrOfSureThings + "\r\n" );
					sw.Write("Number of cells uncovered as a sure thing " + cntOfSureThings + "\r\n\r\n" );

					if(lastGuesses.Count < 100)
						foreach(String s in lastGuesses) 
						{
							sw.Write(s);
						}
					foreach(String s in myGuesses) 
					{
						sw.Write(s);
					}
					sw.Close();

					if (!File.Exists("C:\\minesweeper\\minesweepstats2.txt"))
						fs = File.Create("C:\\minesweeper\\minesweepstats2.txt");
					else
						fs = File.OpenWrite("C:\\minesweeper\\minesweepstats2.txt");
					fs.Seek(0,SeekOrigin.End);
					TimeSpan dateDifference = dt2 - dt1;
					sw = new StreamWriter( fs );
					sw.Write("L " + nbrOfUncCells.ToString("D10") + " " + ((Dem.iTotCols*Dem.iTotRows)-Dem.iTotBombs).ToString("D10") + " " + dateDifference.TotalMilliseconds.ToString("0,000,000.00") + " " +  (dateDifference.TotalMilliseconds/nbrOfUncCells).ToString("0,000,000.00") + 
						" P " + iNp.ToString("D3") + " G " + nbrOfGuesses.ToString("D3") + " S " + nbrOfSureThings.ToString("D3")  + " C " + cntOfSureThings.ToString("D3")  + " # " + Dem.iGameID.ToString("D5") + "\r\n" );
					sw.Close();
					if (Dem.bTraceLight.Enabled)
						System.Diagnostics.Trace.WriteLine("Lost");
					if (Dem.bTraceLight.Enabled || Dem.bTraceMedium.Enabled || Dem.bTraceDeep.Enabled)
					{
						myTextListener.Flush();
						myTextListener.Close();
						Trace.Listeners.Clear();
					}
					return false;
				case State.Won:
					dt2 = System.DateTime.Now;
					dateDifference = dt2 - dt1;
					if (!File.Exists("C:\\minesweeper\\minesweepstats1.txt"))
						fs = File.Create("C:\\minesweeper\\minesweepstats1.txt");
					else
						fs = File.OpenWrite("C:\\minesweeper\\minesweepstats1.txt");

					fs.Seek(0,SeekOrigin.End);

					sw = new StreamWriter( fs );
					sw.Write("W " + ((Dem.iTotCols*Dem.iTotRows)-Dem.iTotBombs).ToString("D10") + " " + dateDifference.TotalMilliseconds.ToString("0,000,000.00") + " " +  (dateDifference.TotalMilliseconds/((Dem.iTotCols*Dem.iTotRows)-Dem.iTotBombs)).ToString("0,000,000.00") +
						" P " + iNp.ToString("D3") + " G " + nbrOfGuesses.ToString("D3") + " S " + nbrOfSureThings.ToString("D3")  + " C " + cntOfSureThings.ToString("D3") + " # " + Dem.iGameID.ToString("D5") + "\r\n" );
					sw.Close();
					if (Dem.bTraceLight.Enabled)
						System.Diagnostics.Trace.WriteLine("Won");
					if (Dem.bTraceLight.Enabled || Dem.bTraceMedium.Enabled || Dem.bTraceDeep.Enabled)
					{
						myTextListener.Flush();
						myTextListener.Close();
						Trace.Listeners.Clear();
					}
					return true;
				default:
					throw (new ApplicationException("Exception Error: undefined state of game"));
			}
		}

		/// <summary>
		/// First half of my deduction: 
		/// Is to find all the bombs that I can, as follows:
		/// For uncovered cells still in play where
		/// the number of covered cells adjacent to this one  
		/// are equal to the cells value. 
		/// Then all the adjacent cells must be bombs!
		/// Add this cell to the list of bombs.
		/// 
		/// P.S.
		/// If I find all the bombs, then I have won.
		/// </summary>
		/// <param name="sc1">All the uncovered cells still in play</param>
		/// <returns>ArrayList of the remaining cells to uncover, If I have won</returns>
		public ArrayList deduceNewBombs(ShadowCell sc1) 
		{
			ArrayList ascs = new ArrayList(); // List of Safe Cells
			ascs.Clear();
			ArrayList adjCells = sc1.getAdjCells(); // Get the adjacent cells to this one
			int cnt = 0;
			// For all adjacent cells to this one
			foreach( ShadowCell sc in adjCells) // O(n) n = (3-8) number of covered cells adjacent to this one
			{
				//IF: [The cell is still covered] and [it is not nullified]
				if (sc.getDisplay() == 'C' && sc.getState() != ShadowCell.CurState.Nullified) 
				{
					cnt++; // The number of cells that remain around this one
				}
			}
			//IF: [The number of covered cells are equal to the number of adjacent bombs] then [they must be bombs]
			if (int.Parse(sc1.getDisplay().ToString()) >= cnt)  
			{
				//IF: [Display value is greater than the number of remaining adjacent cells] Then [there has been a logic error]
				if (int.Parse(sc1.getDisplay().ToString()) > cnt)
					throw (new ApplicationException("Logic Error: number of remaining cells that are covered are too few."));
				// For all adjacent cells, that are bombs 
				foreach( ShadowCell sc in adjCells) 
				{
					//IF: [The cell is still covered] and [it is unknown] then [it is a bomb]
					if (sc.getDisplay() == 'C' && sc.getState() == ShadowCell.CurState.Unknown)
					{
						sc.setState(ShadowCell.CurState.Bomb); // Set state of the cell to bomb
						ArrayList adjToBomb = sc.getAdjCells(); 
						//IF: [I have found all the bombs] then [I am golden]
						if(Dem.iTotBombs - Dem.arrShadowBombs.Count == 0)
						{
							//For all the cells that are covered but not bombs
							foreach( ShadowCell sca in ShadowCell.shadowCellsRowCol ) 
							{
								//IF: [The cell is still covered] and [it is unknown] then [it must not be a bomb]
								if (sca.getDisplay() == 'C' && sca.getState() == ShadowCell.CurState.Unknown)
								{
									ascs.Add(sca); // Then put it on the safe list
								}
							}
						}
					}					
				}
			}
			return ascs; // List of remaining cells.
		}

		/// <summary>
		/// Second half of my deduction: 
		/// Now that we know where some of the bomb(s) are.
		/// I can see if the Bombs adjacent cell(s) value have been reduced to zero or neutralized (Bingo).
		/// All of the cells surrounding a newly neutralized cell are also safe to uncover.
		/// So let's start adding to our list of cells that we will be uncovering.
		/// </summary>
		/// <returns>ArrayList of cells that are not bombs</returns>
		public ArrayList deduceSafeCells() 
		{
			if (Dem.bTraceMedium.Enabled)
				System.Diagnostics.Trace.WriteLine("Deduce Safe Cells");
			
			ArrayList ascs = new ArrayList(); // List of Safe Cells
			// For all bombs I have found so far
			foreach(ShadowCell scb in Dem.arrShadowBombs) 
			{
				bool isBombPlayedOut = true;
				//IF: [The bomb is still in play]
				if ( !scb.isBombPlayedOut ) 
				{
					// For all cells that are adjacent to the bomb
					foreach( ShadowCell sc in scb.getAdjCells()) 
					{
						//IF: [We have not determined the cell state] and [it has been uncovered] 
						if (sc.getState() == ShadowCell.CurState.Unknown && Char.IsDigit(sc.getDisplay()) == true)
						{
							//IF: [This cell now has a calculated value of zero or neutralized]
							if (sc.getCalculatedValue() == 0)
							{
								sc.setState(ShadowCell.CurState.Nullified); // This cell is now nullified
								nbrNeutralized++;
								gameObj.setStatus(TrcDf.NeutralizedCells + nbrNeutralized );
								// For all adjacent cells to the neutralized one
								foreach(ShadowCell sca in sc.getAdjCells()) 
								{
									//IF: [The cell is still covered] and [is not a bomb]
									if (sca.getDisplay() == 'C' && sca.getState() != ShadowCell.CurState.Bomb) 
										ascs.Add(sca); // Then put it on the safe list.
								}
							}
						}
						//IF: [There are any unknown cells for this bomb] then [it is still in play]
						if (sc.getState() == ShadowCell.CurState.Unknown)
							isBombPlayedOut = false;
					}
					scb.isBombPlayedOut = isBombPlayedOut; 
					// IF: [This bomb is now neutralized]
					if (isBombPlayedOut == true)
					{
						nbrNeutralizedBombs++;
						gameObj.setStatus(TrcDf.NeutralizedBombs + this.nbrNeutralizedBombs );
					}
				}
			}
			return ascs; // Safe cells
		}

		/// <summary>
		/// This method is a secondary measure in solving the puzzle that I discovered while analyzing the results 
		/// of my original testing.
		///  
		/// This method will analyze the list of inputs looking for a sure thing, (or inputs that can not be bombs).
		/// This method looks for a consecutive series of inputs either vertically or horizontally aligned
		/// then test to see if these inputs are tightly coupled. Tightly coupled inputs are pairs of 
		/// inputs that are shared between a gate. Some of these series of inputs are solvable. As a result 
		/// of this operation we may discover bombs. So I must also check to see if we have found the remaining 
		/// bombs in play afterwards. If so then we will build the final list of sure things, because we have 
		/// won this game. 
		/// </summary>
		/// <param name="slThreats">Sorted list of all the covered cells in play with a directly calculated potential</param>
		/// <returns>ArrayList of cells that are sure things (cells that are not bombs).</returns>
		public ArrayList anySureThings(SortedList slThreats) 
		{
			if (Dem.bTraceMedium.Enabled)
				System.Diagnostics.Trace.WriteLine("Any Sure Things");

			ArrayList sureThings = new ArrayList(); // The array of sure things found
			ArrayList cInputs  = new ArrayList(); // List of coupled inputs
			SortedList cGates = new SortedList(); // The list of consecutive gates
			SortedList slThreatsColRow = new SortedList(); // List of threats sorted by Col and Row
			ShadowCell lsc = null; // The last or previous shadow cell

			//For the list of inputs that are horizontally aligned 
			foreach(DictionaryEntry iDic in slThreats)
			{
				ShadowCell sc = (ShadowCell)iDic.Value;
				slThreatsColRow.Add(sc.getPos().ToIndexColRow(),sc);
				if (Dem.bAnySureThingExt.Enabled)
				{
					System.Diagnostics.Trace.Write("Input of row column to column row idx1 " + sc.getPos().ToIndexRowCol() + " idx2 "  + sc.getPos().ToIndexColRow() );
					System.Diagnostics.Trace.WriteLine(" Col " + sc.getPos().GetCol() + " Row "  + sc.getPos().GetRow() );
				}
				//If [We are able to compare inputs]
				if (lsc != null)
				{
					if (Dem.bAnySurThing.Enabled)
					{
						System.Diagnostics.Trace.Write("Are these horizontal inputs consecutive idx1 " + lsc.getPos().ToIndexRowCol() + " Col1 "  + lsc.getPos().GetCol() + " Row1 " + lsc.getPos().GetRow()  );
						System.Diagnostics.Trace.WriteLine(" idx2 " + sc.getPos().ToIndexRowCol() + " Col2 "  + sc.getPos().GetCol() + " Row2 " + sc.getPos().GetRow()  );
					}
					//If [inputs are consecutive]
					if (lsc.getPos().ToIndexRowCol()+1==sc.getPos().ToIndexRowCol())
					{
						if (Dem.bAnySurThing.Enabled)
							System.Diagnostics.Trace.WriteLine("Yes they are horizontal consecutive idx1 " + lsc.getPos().ToIndexRowCol() + " idx2 " + sc.getPos().ToIndexRowCol());
						//If [These inputs are tightly coupled]
						if (sc.isTightlyCoupled(lsc,sc, ref cGates, ShadowCell.Orientations.Horizontal) == true)
						{
							//If [we are not currently on a run of inputs]
							if (cInputs.Contains(lsc) == false)
								cInputs.Add(lsc);
							cInputs.Add(sc);
						}
					}
				}
				//If [we are at the end of a run of input]
				if (cInputs.Contains(sc) == false && cInputs.Count > 0)
				{
					//If [We have at least two gates to compare]
					if (cGates.Count > 1)
					{
						CompositeInput ci = new CompositeInput(cGates, CompositeInput.Orientations.Horizontal);
						if (ci.SolvedInputs.Count > 0)
						{
							if (Dem.bTraceLight.Enabled)
								System.Diagnostics.Trace.WriteLine("Count of input that are a sure thing " + ci.SolvedInputs.Count + " horizontal");
							foreach(ShadowCell isc in ci.SolvedInputs)
								sureThings.Add(isc);
						}
					}
					cInputs = new ArrayList();
					cGates = new SortedList();
				}
				lsc = sc;
			}

			//If [We have at least two gates to compare]
			if (cGates.Count > 1)
			{
				CompositeInput ci = new CompositeInput(cGates, CompositeInput.Orientations.Horizontal);
				if (ci.SolvedInputs.Count > 0)
				{
					if (Dem.bTraceLight.Enabled)
						System.Diagnostics.Trace.WriteLine("Count of input that are a sure thing " + ci.SolvedInputs.Count + " horizontal");
					foreach(ShadowCell isc in ci.SolvedInputs)
						sureThings.Add(isc);
				}
			}

			//IF: [I have not found all the bombs]
			if(Dem.iTotBombs - Dem.arrShadowBombs.Count > 0)
			{
				cGates = new SortedList();
				lsc = null; // The last or previous shadow cell
				//For the list of inputs that are vertically aligned 
				foreach(DictionaryEntry iDic in slThreatsColRow)
				{
					ShadowCell sc = (ShadowCell)iDic.Value;
					//If [We are able to compare inputs]
					if (lsc != null)
					{
						if (Dem.bAnySurThing.Enabled)
						{
							System.Diagnostics.Trace.Write("Vertical testing idx1 " + lsc.getPos().ToIndexColRow() + " Col1 "  + lsc.getPos().GetCol() + " Row1 " + lsc.getPos().GetRow()  );
							System.Diagnostics.Trace.WriteLine(" idx2 " + sc.getPos().ToIndexColRow() + " Col2 "  + sc.getPos().GetCol() + " Row2 " + sc.getPos().GetRow()  );
						}
						//If [inputs are consecutive]
						if (lsc.getPos().ToIndexColRow()+1==sc.getPos().ToIndexColRow())
						{
							if (Dem.bAnySurThing.Enabled)
								System.Diagnostics.Trace.WriteLine("Vertical test consecutive idx1 " + lsc.getPos().ToIndexColRow() + " idx2 " + sc.getPos().ToIndexColRow());
							//If [These inputs are tightly coupled]
							if (sc.isTightlyCoupled(lsc,sc, ref cGates, ShadowCell.Orientations.Vertical) == true)
							{
								//If [we are not currently on a run of inputs]
								if (cInputs.Contains(lsc) == false)
									cInputs.Add(lsc);
								cInputs.Add(sc);
							}
						}
					}
					//If [we are at the end of a run of input]
					if (cInputs.Contains(sc) == false && cInputs.Count > 0)
					{
						//If [We have at least two gates to compare]
						if (cGates.Count > 1)
						{
							CompositeInput ci = new CompositeInput(cGates, CompositeInput.Orientations.Vertical);
							if (ci.SolvedInputs.Count > 0)
							{
								if (Dem.bTraceLight.Enabled)
									System.Diagnostics.Trace.WriteLine("Count of input that are a sure thing " + ci.SolvedInputs.Count + " vertical");
								foreach(ShadowCell isc in ci.SolvedInputs)
									sureThings.Add(isc);
							}
						}
						cGates = new SortedList();
						cInputs = new ArrayList();
					}
					lsc = sc;
				}
				//If [We have at least two gates to compare]
				if (cGates.Count > 1)
				{
					CompositeInput ci = new CompositeInput(cGates, CompositeInput.Orientations.Vertical);
					if (ci.SolvedInputs.Count > 0)
					{
						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine("Count of input that are a sure thing " + ci.SolvedInputs.Count + " vertical");
						foreach(ShadowCell isc in ci.SolvedInputs)
							sureThings.Add(isc);
					}
				}
			}

			//IF: [I have found all the bombs] then [I am golden]
			if(Dem.iTotBombs - Dem.arrShadowBombs.Count == 0)
			{
				sureThings.Clear();
				if (Dem.bTraceLight.Enabled)
					System.Diagnostics.Trace.WriteLine("Composite input, I am golden, I have found all the bombs, I win!");
				//For all the cells that are covered but not bombs
				foreach( ShadowCell sca in ShadowCell.shadowCellsRowCol ) 
				{
					//IF: [The cell is still covered] and [it is unknown] then [it must not be a bomb]
					if (sca.getDisplay() == 'C' && sca.getState() == ShadowCell.CurState.Unknown)
					{
						sureThings.Add(sca); // Then put it on the safe list
					}
				}
			}
			
			return sureThings;
		}

		/// <summary>
		/// The logic to make a guess as to which cell to uncover.
		/// Based on the average potential threat of the cells being a bomb.
		/// In certain cases the pattern of cells gives away the bombs position. 
		/// In which case this is no longer a guess and we can have more then one 
		/// cell returned.
		/// </summary>
		/// <returns>ArrayList of cells that are sure things (cells that are not bombs).</returns>
		ArrayList MyBestGuess() 
		{
			if (Dem.bTraceMedium.Enabled)
				System.Diagnostics.Trace.WriteLine("My Best Guess");

			// The array of cells of one to many
			ArrayList lsSC = new ArrayList();
			// Clear the array of string tracking lastGuesses
			lastGuesses = new ArrayList(); 
			// Count of the number of guesses we have made.
			nbrOfGuesses++; 
			// The sorted list of inputs by rowcol
			SortedList inputsByRowCol = new SortedList();
			// The list of remaining covered cells with their lowest potential threat. 
			SortedList adjAprThreats = new SortedList(); 
			// The list of pos from the seeding cell that we got the lowest potential threat from.
			SortedList adjAprThreatsSeed = new SortedList();
			// Sorted list Of lists covered cells in play with a calculated potential.
			SortedList shdCellsRowCol = new SortedList(); 
			// Set of Covered cells without a directly calculated potential.
			ArrayList  cvrShdCellsRowCol = new ArrayList(); 
			// Sort through all the cells 
			foreach( ShadowCell sc in ShadowCell.shadowCellsRowCol ) 
			{
				//IF: [the cell is still in play]
				if (sc.getState() == ShadowCell.CurState.Unknown)
				{
					//IF: [The cell is not covered]
					if (Char.IsDigit(sc.getDisplay()) == true) 
					{
						//IF: [There are no covered cells around this one]
						if (sc.getCountOfAdjCoveredCells() == 0)
							throw (new ApplicationException("Logic Error: Cells internal counts and state out of whack"));
						//iVal AS cells current bomb potential 
						int iVal = (int)(((sc.getCalculatedValue()+.0)/sc.getCountOfAdjCoveredCells())*1000);
						//Key AS cell current bomb potential & cell index 
						long key = long.Parse(iVal.ToString("D4") + sc.getPosAsIndexRowCol().ToString("D7"));

						ArrayList al = new ArrayList();
						//For each [cell around this one]
						foreach( ShadowCell asc in sc.getAdjCells())
						{
							//IF: [the cell is still in play]
							if (asc.getState() == ShadowCell.CurState.Unknown)
							{
								//IF: [The cell is covered] 
								if (Char.IsDigit(asc.getDisplay()) == false) 
								{
									//If: [We don't have this input]
									if (inputsByRowCol.ContainsKey(asc.getPos().ToIndexRowCol()) == false)
										inputsByRowCol.Add(asc.getPos().ToIndexRowCol(),asc);
									al.Add(asc);
									//IF [The adj cell is not already in list of playable cells]
									if (adjAprThreats.ContainsKey(asc.getPosAsIndexRowCol()) == false)
									{
										asc.bombPotentials = new ArrayList();
										asc.bombPotentials.Add(iVal);
										adjAprThreats.Add(asc.getPosAsIndexRowCol(),iVal);
										adjAprThreatsSeed.Add(asc.getPosAsIndexRowCol(),sc.getPosAsIndexRowCol());
									}
									else
									{
										asc.bombPotentials.Add(iVal);
										//IF: [The adj cell is associated with a lower value]
										if (iVal < (int)adjAprThreats.GetByIndex(adjAprThreats.IndexOfKey(asc.getPosAsIndexRowCol())))
										{
											adjAprThreats.SetByIndex(adjAprThreats.IndexOfKey(asc.getPosAsIndexRowCol()),iVal);
											adjAprThreatsSeed.SetByIndex(adjAprThreats.IndexOfKey(asc.getPosAsIndexRowCol()),sc.getPosAsIndexRowCol());
										}
									}
								}
							}
						}

						shdCellsRowCol.Add(key,al);
						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine("Add " + key + " Direct  minval " +  iVal);
						lastGuesses.Add("Add " + key + " Row " + sc.getPos().GetRow()  + " Col " + 
							sc.getPos().GetCol() + " Direct  minvaltot " +  iVal + " nbr of " + al.Count +  "\r\n"); 
					}
					else
					{
						//IF [this cell has no implied bomb potential]
						if ( sc.getAdjCells().Count-(sc.getCountOfAdjCoveredCells()+sc.getCountOfAdjBombs()) == 0) 
						{
							cvrShdCellsRowCol.Add(sc);
						}
					}
				}
			}

			// Keep a local copy of the Bomb count because anySureThings could effect this value.
			int nbrOfBombs = Dem.arrShadowBombs.Count; 
			//If [we are not to exclude anySureThing]
			if (Dem.bExcludeAnySureThing.Enabled == false)
				lsSC = anySureThings(inputsByRowCol); 

			if (lsSC.Count > 0)
			{
				cntOfSureThings += lsSC.Count;
				nbrOfSureThings++;
				Dem.bSureThing = true;
			}

			//IF [There weren't any sure things]
			if (lsSC.Count == 0)
			{
				Dem.bSureThing = false;
				long lkey=0;
				//If [there are any cells with an indirect threat]
				if (cvrShdCellsRowCol.Count > 0)
				{
					ArrayList alSet = null;
					SortedList slSets = new SortedList();
					int iAprTot = 0;
					//Collect the threats grouped by owner (the cell whose value is reflected).
					foreach(DictionaryEntry aTh in adjAprThreats)
					{ 
						int posRowCol = (int)adjAprThreatsSeed.GetByIndex(adjAprThreats.IndexOfKey(aTh.Key));
						//If [We have not accounted for this threat]
						if (slSets.ContainsKey(posRowCol) == false)
						{
							alSet = new ArrayList();
							alSet.Add(((int)aTh.Value));
							slSets.Add(posRowCol,alSet);
							if (Dem.bTraceLight.Enabled)
								System.Diagnostics.Trace.WriteLine("Set Direct threat of " + ((int)aTh.Value) +
									" @ " + new Pos((int)aTh.Key).GetRow() + "," + new Pos((int)aTh.Key).GetCol() +
									" from " + new Pos(posRowCol).GetRow() + "," + new Pos(posRowCol).GetCol());
						}
						else
						{
							((ArrayList)slSets.GetByIndex(slSets.IndexOfKey(posRowCol))).Add(((int)aTh.Value));
							if (Dem.bTraceLight.Enabled)
								System.Diagnostics.Trace.WriteLine("Sub Direct threat of " + ((int)aTh.Value) + 
									" @ " + new Pos((int)aTh.Key).GetRow() + "," + new Pos((int)aTh.Key).GetCol() +
									" from " + new Pos(posRowCol).GetRow() + "," + new Pos(posRowCol).GetCol());
						}
					}

					foreach(DictionaryEntry aTh in slSets)
					{
						ArrayList alTh = (ArrayList)aTh.Value;
						int cnt = ((ShadowCell)ShadowCell.shadowCellsRowCol[(int)aTh.Key]).getCountOfAdjCoveredCells();
						int val = ((ShadowCell)ShadowCell.shadowCellsRowCol[(int)aTh.Key]).getCalculatedValue();
						//If [we have all the cells of this threat]
						if (alTh.Count == cnt)
						{
							iAprTot += val*1000; 
							if (Dem.bTraceLight.Enabled)
								System.Diagnostics.Trace.WriteLine("Add Direct threat of " 
									+ val*1000 + " cnt " + cnt + " sub " + ((int)alTh[0]) + " from " + 
									new Pos((int)aTh.Key).GetRow() + "," + new Pos((int)aTh.Key).GetCol());
						}
						else
						{
							int a = (int)alTh[0];
								iAprTot +=  a*alTh.Count;
								if (Dem.bTraceLight.Enabled)
									System.Diagnostics.Trace.WriteLine("#Add Direct threat of " 
										+ a + " times count " + alTh.Count + " from " + 
										new Pos((int)aTh.Key).GetRow() + "," + new Pos((int)aTh.Key).GetCol());
						}
						if (Dem.bTraceLight.Enabled)
								System.Diagnostics.Trace.WriteLine("    threat total " + iAprTot); 

					}

					int nbr = Dem.iTotBombs - nbrOfBombs; // The number of bombs remaining
					//Reduce the number of bombs remaining by the sum of bomb threats known
					double adjnbr = nbr - iAprTot/1000.0;

					//If [we fall outside the range]
					if (adjnbr < 0)
					{
						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine("Adjusted number of bomb is outside of range " + 
								adjnbr + " setting to zero");
						adjnbr = 0;
					}

					//If [we fall outside the range]
					if (adjnbr > cvrShdCellsRowCol.Count) 
					{
						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine("Adjusted number of bomb is outside of range " 
								+ adjnbr + " setting to number of adjusted squares " + cvrShdCellsRowCol.Count );
						adjnbr = cvrShdCellsRowCol.Count;
					}

					lkey = (long)((adjnbr/(1.0*cvrShdCellsRowCol.Count))*1000L);
					String strIndir = ("Indirect cells have a bomb potential of " + lkey + 
						"\r\n  where the indirect cell count is " + 
						cvrShdCellsRowCol.Count + "\r\n  number of bombs remaining are " + nbr + 
						"\r\n  implied number of bombs found was " + iAprTot +
						"\r\n  giving the implied indirect number of bombs of " + adjnbr);

					if (Dem.bTraceLight.Enabled)
						System.Diagnostics.Trace.WriteLine(strIndir);
					lastGuesses.Add(strIndir + "\r\n");

					bool bIndirect = true;
					//If [There are direct threats present]
					if (shdCellsRowCol.Count != 0)
						bIndirect = lkey <= ((long)shdCellsRowCol.GetKey(0))/10000000; 

					//If [The indirect threat is a better bet]
					if (bIndirect)
					{
						ArrayList al = new ArrayList();
						//For all the cells with an indirect threat
						foreach(ShadowCell scx in cvrShdCellsRowCol)
						{
							scx.bombPotentials = new ArrayList();
							al.Add(scx);
						}
						if(al.Count > 0)
						{
							String ckey = (lkey).ToString("D4") + "9999999";
							if (Dem.bTraceLight.Enabled)
								System.Diagnostics.Trace.WriteLine("Add " + ckey + " inDirect");
							shdCellsRowCol.Add( long.Parse(ckey) ,al);
							lastGuesses.Add("indirect Covered cells count " + al.Count + "\r\n"  );
						}
					}
				}
				if (Dem.bTraceLight.Enabled)
					System.Diagnostics.Trace.WriteLine("-");

				//IF: [There are no cells to pick from] then [there must be a logic error]
				if (shdCellsRowCol.Count == 0 )
					throw (new ApplicationException("Logic Error: Guessing the cells"));

				int toPickFrom = 0;
				bool bLastPick = true;
				lkey = ((long)shdCellsRowCol.GetKey(0))/10000000L;
				// Collect the set of cells with the lowest threat
				for(int j=0; j<shdCellsRowCol.Count;j++) 
				{
					//IF: [The potential is the same as previous]
					if( lkey == ((long)(shdCellsRowCol.GetKey(j))/10000000)) 
					{
						toPickFrom++;
						String str = ("Last guess including element " + ((long)shdCellsRowCol.GetKey(j)));
						lastGuesses.Add(str + "\r\n");
						if (Dem.bTraceLight.Enabled)
						{
							System.Diagnostics.Trace.WriteLine(str);
							System.Diagnostics.Trace.WriteLine("--");
						}
					}
					else
					{
						if (bLastPick == true)
						{
							bLastPick = false;
							lastGuesses.Add("Guess Spread " + (((long)shdCellsRowCol.GetKey(j))/10000000 - lkey) + "\r\n"  );
							if (Dem.bTraceLight.Enabled)
								System.Diagnostics.Trace.WriteLine("Guess Spread " + (((long)shdCellsRowCol.GetKey(j))/10000000 - lkey));
							break;
						}
					}
				}

				//IF: [There were on certain moves to make]
				if (lsSC.Count == 0)
				{
					int r = MyRand(toPickFrom);
					ArrayList al = (ArrayList)(shdCellsRowCol.GetByIndex(r));

					lastGuesses.Add("Last guess picked element with " + shdCellsRowCol.GetKey(r) + " out of " + toPickFrom + "\r\n" );
					if (Dem.bTraceLight.Enabled)
						System.Diagnostics.Trace.WriteLine("Last guess picked element with " + shdCellsRowCol.GetKey(r) + " out of " + toPickFrom );

					r = MyRand(al.Count);

					ShadowCell fsc = ((ShadowCell)al[r]);  

					if (al.Count < 50)
					{
						foreach(ShadowCell gsc in al)
						{
							String sx456 = "Cells to pick from @R" + gsc.getPos().GetRow() + "C"  + gsc.getPos().GetCol() + " bomb cnt " + gsc.bombPotentials.Count;

							if (gsc.bombPotentials.Count > 0)
							{
								gsc.bombPotentials.Sort();
								foreach(int bPot in gsc.bombPotentials)
								{
									sx456 += " pot " + bPot;
								}
							}
							lastGuesses.Add(sx456 + "\r\n");
							if (Dem.bTraceLight.Enabled)
								System.Diagnostics.Trace.WriteLine(sx456);
						}
					}
					string tmp1 = " Row. " + fsc.getPos().GetRow() + " col. "  + fsc.getPos().GetCol() + " out of " + al.Count + " Pot " + ((long)shdCellsRowCol.GetKey(0)/10000000).ToString() ;
					if (Dem.bTraceLight.Enabled)
						System.Diagnostics.Trace.WriteLine("Last guess picked" + tmp1 );
					lastGuesses.Add("Last guess picked " +  tmp1 + "\r\n"  );
					myGuesses.Add("Guess picked " + tmp1 + "\r\n" );

					//The list of shadow cells to use
					lsSC.Add(fsc);
				}
			}

			//IF: [There are no cells found] then [I have a logic error]
			if (lsSC.Count == 0)
				throw (new ApplicationException("Logic Error: There are no cells guessed!"));

			if (Dem.bTraceLight.Enabled)
				System.Diagnostics.Trace.WriteLine("return from MyBestGuess " + lsSC.Count );
			return lsSC;
		}

		/// <summary>
		/// Wrapper the random function, so I can vary it if necessary
		/// </summary>
		/// <param name="limit">the value to stay under</param>
		/// <returns>the random value</returns>
		private int MyRand(int limit)
		{
			int a = limit;
			int i = 0;
			while( (a/=8)>0) i++;
			if (i==0) i=1;
			byte[] randomVals = new Byte[i];
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			rng.GetBytes(randomVals);
			int rv = ConnectTheBytes(randomVals);
			if (rv<0)
				rv*=-1;

			return rv % limit;
		}

		/// <summary>
		/// Constructs an integer out of an array of bytes
		/// </summary>
		/// <param name="arv">the array of bytes to be used</param>
		/// <returns>integer value</returns>
		private int ConnectTheBytes(byte[] arv)
		{
			int rv = 0;
			int factor=1;
			foreach(byte rb in arv)
			{
				rv+=rb*factor;
				factor<<=8;
			}
			return rv;
		}


	}

	/// <summary>
	/// A method of reflecting the change in state back to the gates that own the input.
	/// </summary>
	interface InputStates 
	{
		// Property signatures:
		Input.states state  
		{
			get; 
			set; 
		}
	}

	/// <summary>
	/// A input being shared between gates of that make up the composite input.
	/// </summary>
	class Input : InputStates
	{
		public ShadowCell sc = null;
		public enum states { unknown=-1, on=1, off=0 };
		private states pState = states.unknown;
		public bool bCoupled = false;
		public int index;

		private CompositeInput cmpInput;
		/// <summary>
		/// The list of gates that are associated to this input.
		/// </summary>
		public ArrayList InpSetOwners = new ArrayList();

		/// <summary>
		/// Creates a new Input for the composite input set.
		/// </summary>
		/// <param name="sc">ShadowCell as input</param>
		/// <param name="myGate">Associated Gate</param>
		/// <param name="cmpInput">Owning Composite input</param>
		public Input (ShadowCell sc, Gate myGate, CompositeInput cmpInput) 
		{
			this.cmpInput = cmpInput;
			this.sc = sc;
			InpSetOwners.Add(myGate);
		}

		/// <summary>
		/// Adds a gate to the set of owners for this input.
		/// </summary>
		/// <param name="myGate"></param>
		public void AddOwner(Gate myGate)
		{
			if (InpSetOwners.Contains(myGate) == false)
				InpSetOwners.Add(myGate);
		}

		/// <summary>
		/// Deletes a gate from the set of owners
		/// </summary>
		/// <param name="myGate"></param>
		public void DelOwner(Gate myGate)
		{
			InpSetOwners.Remove(myGate);
		}

		// Property implementation:
		public states state 
		{
			get 
			{
				return pState;
			}

			set 
			{
				//If: [only the first time]
				if (pState == Input.states.unknown)
				{
					pState = value; 
					//If [This has become a safe input]
					if (pState == Input.states.off)
						cmpInput.AddSolvedInput(this);
					//If [This is a bomb]
					if (pState == Input.states.on)
					{
						sc.setState(ShadowCell.CurState.Bomb);
						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine("Input is on mark as bomb, Row " + sc.getPos().GetRow() + " Col " + sc.getPos().GetCol());
					}
					if (Dem.bTraceLight.Enabled)
						System.Diagnostics.Trace.WriteLine("Count of owners " + InpSetOwners.Count);
					//Reflect the inputs state change to all of the gates that are tightly coupled
					foreach(Gate iPSet in InpSetOwners)
					{
						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine("Reflect input change to owner row " + iPSet.sc.getPos().GetRow() + " col " + iPSet.sc.getPos().GetCol());
						iPSet.InputChange(this);
					}
				}
				else
				{
					//If [I have a logic error]
					if (pState != value)
						throw( new Exception("Input set state logic error."));
				}
			}
		}
	}

	/// <summary>
	/// A group of inputs of a gate of a composite input.
	/// </summary>
	class InputSet
	{
		/// <summary>
		/// Unknown not solved for; Solved state known; Removed AND with one or more input low, 
		/// </summary>
		public enum States { Unknow=0, Solved=1, Removed=2};
		public States State = States.Unknow;
		public SortedList slInputs= new SortedList();

		public Gate myGate = null;
	}

	/// <summary>
	/// Provides a method to reflect the gates state change back to the composite input. 
	/// </summary>
	interface GateState 
	{
		// Property signatures:
		bool IsSolved  
		{
			get; 
			set; 
		}
	}

	/// <summary>
	/// A gate that contains the set of inputs that we are attempting to solve.
	/// </summary>
	class Gate : GateState
	{
		/// <summary>
		/// The list of tightly coupled input associated with this gate.
		/// </summary>
		public ArrayList tciputs = new ArrayList();
		/// <summary>
		/// The types of operator that a gate can have
		/// </summary>
		public enum Operators { And=0, Or=1, NA=-1};
		/// <summary>
		/// Has this gate been solved
		/// </summary>
		private bool bSolved = false;
		/// <summary>
		/// The shadowcell of this gate 
		/// </summary>
		public ShadowCell sc = null;
		/// <summary>
		/// The type of gate myOperator { AND, OR, NA } 
		/// </summary>
		public Operators myOperator = Operators.NA;
		/// <summary>
		/// The related unions of InputSets of tightly coupled AND gates (for a prevous relationship). 
		/// (related unions as indexed pairs {0u1},{1u2},{2u0})
		/// </summary>
		public static readonly int[] unionsOfAndPrv = new int[]{1,2,0};
		/// <summary>
		/// The related unions of InputSets of tightly coupled AND gates (for a latter relationship). 
		/// (related unions as indexed pairs {1u0},{0u2},{2u1})
		/// </summary>
		public static readonly int[] unionsOfAndLtr = new int[]{2,0,1};
		/// <summary>
		/// Array of InputSets this gate references
		/// </summary>
		public Array arInputSets;
		/// <summary>
		/// Array of Inputs this gate references
		/// </summary>
		public Array arInputs;
		/// <summary>
		/// The CompositeInput that owns this gate
		/// </summary>
		private CompositeInput compInput;

		/// <summary>
		/// The constructor
		/// </summary>
		/// <param name="cmpInp"></param>
		public Gate(CompositeInput cmpInp)
		{
			compInput = cmpInp;
		}

		// Property implementation:
		public bool IsSolved 
		{
			get 
			{
				return bSolved;
			}

			set 
			{
				//If [we have not recorded this event yet]
				if (bSolved == false)
					compInput.iCntSolvedGates++;
				bSolved = value; 
				//Reflect the gates state change to the composite input.
			}
		}

		/// <summary>
		/// Reflects changes to the inputs of this gate
		/// </summary>
		/// <param name="iPut"></param>
		public void InputChange(Input iPut)
		{
			{
				if (Dem.bTraceLight.Enabled)
					System.Diagnostics.Trace.WriteLine("InputChange Gate Row " + sc.getPos().GetRow() + " Col " + sc.getPos().GetCol());   
				//If [I am a OR Gate]
				if (myOperator == Operators.Or)
				{
					//If [the input is on]
					if (iPut.state == Input.states.on)
					{
						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine("   Input OR solved " + iPut.index + " is on row,col" + 
								iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol()   );
						IsSolved = true;
						foreach(DictionaryEntry iDic  in ((InputSet)arInputSets.GetValue(0)).slInputs )
						{
							Input iPut1 = (Input)iDic.Value;
							if( iPut1.state == Input.states.unknown )
								iPut1.state = Input.states.off;
						}
						foreach(DictionaryEntry iDic  in ((InputSet)arInputSets.GetValue(1)).slInputs )
						{
							Input iPut1 = (Input)iDic.Value;
							if( iPut1.state == Input.states.unknown )
								iPut1.state = Input.states.off;
						}
					}
					else //If [the input is off]
					{
						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine("   Input OR " + iPut.index + " is off row,col " +
								iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
						int iCntUnknowns=0;
						int iCntOn=0;
						foreach(DictionaryEntry iDic in ((InputSet)arInputSets.GetValue(0)).slInputs)
						{
							Input iPut1 = (Input)iDic.Value;
							if( iPut1.state == Input.states.unknown )
								iCntUnknowns ++;

							if( iPut1.state == Input.states.on )
								iCntOn++;
						}
						foreach(DictionaryEntry iDic in ((InputSet)arInputSets.GetValue(1)).slInputs)
						{
							Input iPut1 = (Input)iDic.Value;
							if( iPut1.state == Input.states.unknown )
								iCntUnknowns ++;

							if( iPut1.state == Input.states.on )
								iCntOn++;
						}

						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine("  OR Unknowns " + iCntUnknowns + " ONs " + iCntOn );

						//If [an input has been switched on]
						if (iCntOn > 0)
						{
							//If [only one input is switched on]
							if (iCntOn == 1)
							{
								foreach(DictionaryEntry iDic in ((InputSet)arInputSets.GetValue(0)).slInputs)
								{
									Input iPut1 = (Input)iDic.Value;
									if( iPut1.state == Input.states.unknown )
									{
										iPut1.state = Input.states.off;
										if (Dem.bTraceLight.Enabled)
											System.Diagnostics.Trace.WriteLine("   Input solved1 " + iPut.index + " is off row,col " +
												iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
									}
								}
								foreach(DictionaryEntry iDic in ((InputSet)arInputSets.GetValue(1)).slInputs)
								{
									Input iPut1 = (Input)iDic.Value;
									if( iPut1.state == Input.states.unknown )
									{
										iPut1.state = Input.states.off;
										if (Dem.bTraceLight.Enabled)
											System.Diagnostics.Trace.WriteLine("   Input solved2 " + iPut.index + " is off row,col " +
												iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
									}
								}
							}
							else
								throw( new Exception("Logic error more than one input is on, OR Gate Row " + sc.getPos().GetRow() + " Col " + sc.getPos().GetCol()));
						}
						else
						{
							//If [there is only one unknown left] then [it must be true]
							if (iCntUnknowns == 1)
							{
								IsSolved = true;
								foreach(DictionaryEntry iDic in ((InputSet)arInputSets.GetValue(0)).slInputs)
								{
									Input iPut1 = (Input)iDic.Value;
									if( iPut1.state == Input.states.unknown )
									{
										iPut1.state = Input.states.on;
										if (Dem.bTraceLight.Enabled)
											System.Diagnostics.Trace.WriteLine("   Input solved1 " + iPut.index + " is on row,col " +
												iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
									}
								}
								foreach(DictionaryEntry iDic in ((InputSet)arInputSets.GetValue(1)).slInputs)
								{
									Input iPut1 = (Input)iDic.Value;
									if( iPut1.state == Input.states.unknown )
									{
										iPut1.state = Input.states.on;
										if (Dem.bTraceLight.Enabled)
											System.Diagnostics.Trace.WriteLine("   Input solved2 " + iPut.index + " is on row,col " +
												iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
									}
								}
							}
						}
					}
				}

				//If [I am an AND gate]
				if (myOperator == Operators.And)
				{
					Array arTmpInputs = Array.CreateInstance( typeof(Input),3);
					arTmpInputs.SetValue(((InputSet)arInputSets.GetValue(0)).slInputs.GetByIndex(0),0);
					arTmpInputs.SetValue(((InputSet)arInputSets.GetValue(0)).slInputs.GetByIndex(1),1);
					arTmpInputs.SetValue(((InputSet)arInputSets.GetValue(1)).slInputs.GetByIndex(1),2);
					 long ofs = iPut.index - ((Input)((InputSet)arInputSets.GetValue(0)).slInputs.GetByIndex(0)).index;
					if (Dem.bTraceLight.Enabled)
						System.Diagnostics.Trace.WriteLine(" And gate Inputs " +
							((Input)arTmpInputs.GetValue(0)).index + " " + 
							((Input)arTmpInputs.GetValue(1)).index + " " + 
							((Input)arTmpInputs.GetValue(2)).index + " and ofs " + ofs );
					//If [the input is on]
					if (iPut.state == Input.states.on)
					{
						if (Dem.bTraceLight.Enabled)
							System.Diagnostics.Trace.WriteLine("  Input AND " + iPut.index + " is on row,col " +
								iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
						switch(ofs)
						{
							case 0:
								((InputSet)arInputSets.GetValue(1)).State = InputSet.States.Removed;			
								//If [the second input is on]
								if (((Input)arTmpInputs.GetValue(1)).state == Input.states.on)
								{
									if (Dem.bTraceLight.Enabled)
										System.Diagnostics.Trace.WriteLine("  Input AND solved 0 1 " + iPut.index + " is on row,col " +
											iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
									IsSolved = true;
									((InputSet)arInputSets.GetValue(2)).State = InputSet.States.Removed;			
									((Input)arTmpInputs.GetValue(2)).state = Input.states.off;
								}
								//If [the third input is on]
								if (((Input)arTmpInputs.GetValue(2)).state == Input.states.on)
								{
									if (Dem.bTraceLight.Enabled)
										System.Diagnostics.Trace.WriteLine("  Input AND solved 0 2 " + iPut.index + " is on row,col " +
											iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol());
									IsSolved = true;
									((InputSet)arInputSets.GetValue(0)).State = InputSet.States.Removed;			
									((Input)arTmpInputs.GetValue(1)).state = Input.states.off;
								}
								break;
							case 1:
								((InputSet)arInputSets.GetValue(2)).State = InputSet.States.Removed;			
								//If [the first input is on]
								if (((Input)arTmpInputs.GetValue(0)).state == Input.states.on)
								{
									if (Dem.bTraceLight.Enabled)
										System.Diagnostics.Trace.WriteLine("  Input AND solved 1 0 " + iPut.index + " is on row,col " + 
											iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
									IsSolved = true;
									((InputSet)arInputSets.GetValue(1)).State = InputSet.States.Removed;			
									((Input)arTmpInputs.GetValue(2)).state = Input.states.off;
								}
								//If [the third input is on]
								if (((Input)arTmpInputs.GetValue(2)).state == Input.states.on)
								{
									if (Dem.bTraceLight.Enabled)
										System.Diagnostics.Trace.WriteLine("  Input AND solved 1 2 " + iPut.index + " is on row,col " +
											iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
									IsSolved = true;
									((InputSet)arInputSets.GetValue(0)).State = InputSet.States.Removed;			
									((Input)arTmpInputs.GetValue(0)).state = Input.states.off;
								}
								break;
							case 2:
								((InputSet)arInputSets.GetValue(0)).State = InputSet.States.Removed;			
								//If [the first input is on]
								if (((Input)arTmpInputs.GetValue(0)).state == Input.states.on)
								{
									if (Dem.bTraceLight.Enabled)
										System.Diagnostics.Trace.WriteLine("  Input AND solved 2 0 " + iPut.index + " is on row,col " + 
											iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
									IsSolved = true;
									((InputSet)arInputSets.GetValue(1)).State = InputSet.States.Removed;			
									((Input)arTmpInputs.GetValue(1)).state = Input.states.off;
								}
								//If [the second input is on]
								if (((Input)arTmpInputs.GetValue(1)).state == Input.states.on)
								{
									if (Dem.bTraceLight.Enabled)
										System.Diagnostics.Trace.WriteLine("  Input AND solved 2 1 " + iPut.index + " is on row,col " +
											iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
									IsSolved = true;
									((InputSet)arInputSets.GetValue(2)).State = InputSet.States.Removed;			
									((Input)arTmpInputs.GetValue(0)).state = Input.states.off;
								}
								break;
						}
					}
					else //If [the input is off]
					{
						switch(ofs)
						{
							case 0:
								if (Dem.bTraceLight.Enabled)
									System.Diagnostics.Trace.WriteLine("  Input AND solved 0 " + iPut.index + " is off row,col " +
										iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
								IsSolved = true;
								((InputSet)arInputSets.GetValue(0)).State = InputSet.States.Removed;			
								((InputSet)arInputSets.GetValue(2)).State = InputSet.States.Removed;			
								if (((Input)arTmpInputs.GetValue(1)).state != Input.states.off)
									((Input)arTmpInputs.GetValue(1)).state = Input.states.on;
								else 
									throw( new Exception("And input is off ofs " + ofs) );
								if (((Input)arTmpInputs.GetValue(2)).state != Input.states.off)
									((Input)arTmpInputs.GetValue(2)).state = Input.states.on;
								else 
									throw( new Exception("And input is off ofs " + ofs) );
								break;
							case 1:
								if (Dem.bTraceLight.Enabled)
									System.Diagnostics.Trace.WriteLine("  Input AND solved 1 " + iPut.index + " is off row,col " +
										iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
								IsSolved = true;
								((InputSet)arInputSets.GetValue(0)).State = InputSet.States.Removed;			
								((InputSet)arInputSets.GetValue(1)).State = InputSet.States.Removed;			
								if (((Input)arTmpInputs.GetValue(0)).state != Input.states.off)
									((Input)arTmpInputs.GetValue(0)).state = Input.states.on;
								else 
									throw( new Exception("And input is off ofs " + ofs) );
								if (((Input)arTmpInputs.GetValue(2)).state != Input.states.off)
									((Input)arTmpInputs.GetValue(2)).state = Input.states.on;
								else 
									throw( new Exception("And input is off ofs " + ofs) );
								break;
							case 2:
								if (Dem.bTraceLight.Enabled)
									System.Diagnostics.Trace.WriteLine("  Input AND solved 2 " + iPut.index + " is off row,col " +
										iPut.sc.getPos().GetRow() + "," + iPut.sc.getPos().GetCol() );
								IsSolved = true;
								((InputSet)arInputSets.GetValue(1)).State = InputSet.States.Removed;			
								((InputSet)arInputSets.GetValue(2)).State = InputSet.States.Removed;			
								if (((Input)arTmpInputs.GetValue(0)).state != Input.states.off)
									((Input)arTmpInputs.GetValue(0)).state = Input.states.on;
								else 
									throw( new Exception("And input is off ofs " + ofs) );
								if (((Input)arTmpInputs.GetValue(1)).state != Input.states.off)
									((Input)arTmpInputs.GetValue(1)).state = Input.states.on;
								else 
									throw( new Exception("And input is off ofs " + ofs) );
								break;
						}
					}
				}
			}
		}
	}

	/// <summary>
	/// The composite input made up of two or more gates and their inputs.
	/// Used to analyze the complex relations between gates that are tightly coupled.
	/// In the hope of determining the states of the inputs.
	/// </summary>
	class CompositeInput 
	{
		FileStream fs;
		StreamWriter sw;

		/// <summary>
		/// The list of orientations inputs we have
		/// </summary>
		public enum Orientations { Vertical=0, Horizontal=2, Unknown=3 };
		/// <summary>
		/// The orientation of the inputs being solved.
		/// </summary>
		private Orientations orientation = CompositeInput.Orientations.Unknown;
		/// <summary>
		/// The temporary list of gates that make up this composite input.
		/// </summary>
		private ArrayList alGates;
		/// <summary>
		/// The final sorted list of gates that make up this composite input
		/// </summary>
		private SortedList slGates = new SortedList();
		/// <summary>
		/// The Count of gates that have been solved
		/// </summary>
		public int iCntSolvedGates = 0; 
		/// <summary>
		/// The unique list of tightly coupled inputs that make up the composite input
		/// </summary>
		public SortedList slCoupledCompositeInputs = new SortedList(); 
		/// <summary>
		/// The unique list of tightly coupled inputs that make up the composite input
		/// </summary>
		public SortedList slUnCoupledCompositeInputs = new SortedList(); 
		/// <summary>
		/// The list of solved inputs as shadowCellsRowCol.
		/// </summary>
		public ArrayList SolvedInputs = new ArrayList(); 

		/// <summary>
		/// Add an input to the list of safe inputs to select.
		/// Safe Inputs are deemed to be off or not a bomb.
		/// </summary>
		/// <param name="iPut">Input = Off</param>
		public void AddSolvedInput(Input iPut)
		{
			try 
			{
				if (SolvedInputs.Contains(iPut.sc) == false)
					SolvedInputs.Add(iPut.sc); 
			}
			catch (Exception )
			{}
		}

		/// <summary>
		/// Finished when all the gates solved.
		/// </summary>
		/// <returns>true if all the gates have been solved</returns>
		private bool Solved()
		{
			if (iCntSolvedGates > alGates.Count)
				throw( new Exception("Too many gates solved"));
			return iCntSolvedGates == alGates.Count;
		}

		/// <summary>
		/// Constructs a composite input of all of the uniquely tightly coupled inputs given.
		/// Inputs are bound to sub sets of logical gates of type 'AND' and 'OR'.
		/// We are some times able to deduce some or all of the inputs states using the 
		/// rules of 'Not OR';'NOT And' and 'Compound ANDS'
		/// </summary>
		/// <param name="cGates">The list of gates that makeup the composite input</param>
		/// <param name="orientation">The orientation of the gates being solved</param>
		public CompositeInput( SortedList cGates, Orientations orientation  )
		{
			int idx;
			SortedList sGates = new SortedList();

			string sb = "";
			string stmp0 = "\r\n\r\n### STARTING NEW COMPOSITE INPUT - Oriented" 
				+ (Orientations.Horizontal == orientation ? " Horizontal\r\n" : " Vertical\r\n");
			if (Dem.bCompInp.Enabled) sb += stmp0;
			if (Dem.bTraceDeep.Enabled) System.Diagnostics.Trace.WriteLine(stmp0);

			this.orientation = orientation;
			alGates = new ArrayList(sGates.Count);
			ArrayList alSharedInputs = new ArrayList();
			SortedList slCoupledInputs = new SortedList();

			if (Dem.bCompInp.Enabled)
				sb += "The number of wouldbe gates " + cGates.Count + "\r\n";

			Gate lastGate = null; 
			//For all the wouldbe gates given
			foreach(DictionaryEntry iDic in cGates)
			{
				ShadowCell scWouldBeGate1 = ((ShadowCell)iDic.Value);
				Gate myGate = new Gate(this);
				SortedList slIPuts = new SortedList();
				int iCnt = 0;
				int index = orientation == Orientations.Vertical ? 
					scWouldBeGate1.getPos().ToIndexColRow() : scWouldBeGate1.getPos().ToIndexRowCol();
				string rowcol = scWouldBeGate1.getPos().GetRow() + "," + scWouldBeGate1.getPos().GetCol(); 

				myGate.arInputs = Array.CreateInstance( typeof(Input), scWouldBeGate1.getCountOfAdjCoveredCells());
				myGate.sc = scWouldBeGate1;
				//If [this is a solvable OR gate]
				if (scWouldBeGate1.getCalculatedValue() == 1) 
				{
					myGate.myOperator = Gate.Operators.Or;
					myGate.arInputSets = Array.CreateInstance( typeof(InputSet), 2);
					myGate.arInputSets.SetValue(new InputSet(),0);
					myGate.arInputSets.SetValue(new InputSet(),1);
					if (Dem.bCompInp.Enabled)
						sb += "- Type of ( OR ) gate " + index + " row,col " + rowcol + "\r\n";

				}    //If [This is a solvable AND Gate]
				else if (scWouldBeGate1.getCalculatedValue() == 2 && scWouldBeGate1.getCountOfAdjCoveredCells() == 3)
				{
					myGate.myOperator = Gate.Operators.And;
					myGate.arInputSets = Array.CreateInstance( typeof(InputSet), 3);
					myGate.arInputSets.SetValue(new InputSet(),0);
					myGate.arInputSets.SetValue(new InputSet(),1);
					myGate.arInputSets.SetValue(new InputSet(),2);
					if (Dem.bCompInp.Enabled)
						sb += "- Type of  ( AND ) gate " + index + " row,col " + rowcol + "\r\n";
				} 
				else
				{
					myGate.myOperator = Gate.Operators.NA;
					myGate.arInputSets = Array.CreateInstance( typeof(InputSet), 0);
					if (Dem.bCompInp.Enabled)
						sb += "- Type of ( NA ) gate " + index + " row,col " + rowcol + "\r\n";
					continue;
				}

				ArrayList prvSharedInputs = new ArrayList();
				ArrayList folSharedInputs = new ArrayList();
				//IF [there is a following gate]
				if (cGates.IndexOfKey(iDic.Key) < cGates.Count-1)
				{
					ShadowCell scWouldBeGateNext = (ShadowCell)cGates.GetByIndex(cGates.IndexOfKey(iDic.Key)+1);
					//IF [the next gate is of type 'AND or 'OR']
					if (scWouldBeGateNext.getCalculatedValue() == 1 || scWouldBeGateNext.getCountOfAdjCoveredCells() == 3)
					{
						Orientations orient = (orientation == Orientations.Vertical) ? Orientations.Horizontal:Orientations.Vertical;
						ShadowCell scWouldBeGate2 = (ShadowCell)cGates.GetByIndex(cGates.IndexOfKey(iDic.Key)+1);
						//Get the list of tightly coupled inputs
						folSharedInputs = FindSharedInputs(scWouldBeGate1, scWouldBeGate2, orient);
						if (Dem.bCompInp.Enabled)
							sb += "The number of latter coupled gates " + folSharedInputs.Count + "\r\n";
					}
				}

				//IF [there is a previous gate]
				if (cGates.IndexOfKey(iDic.Key) != 0 && lastGate != null)
				{
					//IF [the previous gate is of type 'AND or 'OR']
					if (lastGate.myOperator != Gate.Operators.NA)
					{
						Orientations orient = orientation == Orientations.Vertical ? Orientations.Horizontal:Orientations.Vertical;
						ShadowCell scWouldBeGate2 = (ShadowCell)cGates.GetByIndex(cGates.IndexOfKey(iDic.Key)-1);
						//Get the list of tightly coupled inputs
						prvSharedInputs = FindSharedInputs(scWouldBeGate1, scWouldBeGate2, orient);
						if (Dem.bCompInp.Enabled)
							sb += "The number of previous coupled gates " + prvSharedInputs.Count + "\r\n";
					}
				}

				//For all the following coupled inputs we have 
				foreach(ShadowCell input in folSharedInputs)
				{
					//If [we do not already have this one]
					if (prvSharedInputs.Contains(input) == false)
						prvSharedInputs.Add(input);
				}
				if (Dem.bCompInp.Enabled)
					sb += "The number of coupled gates total " + prvSharedInputs.Count + "\r\n";

				//If [this is a tightly coupled gate]
				if (prvSharedInputs.Count>1)
				{
					if (Dem.bCompInp.Enabled)
						sb += "Gate is tightly coupled\r\n";

					string sKey = "";
					//For all the tightly coupled inputs of this wouldbe gate
					foreach(ShadowCell input in prvSharedInputs)
					{
						//If [the Key has a previous entry]
						if (sKey.Length > 0)
							sKey+=",";

						//If [the input is not already in the list of inputs]
						if ((idx = alSharedInputs.IndexOf(input)) == -1)
						{
							int idxcnt = alSharedInputs.Count;
							Input aInput = new Input(input, myGate, this);
							aInput.index = idxcnt;
							aInput.bCoupled = true;
							slCoupledInputs.Add(idxcnt,aInput);
							sKey += ((int)(idxcnt)).ToString("D2");
							alSharedInputs.Add(input);
							if (Dem.bCompInp.Enabled)
								sb += "  Coupled input " + idxcnt + " row " + input.getPos().GetRow() + 
									" col " + input.getPos().GetCol() + "\r\n";
						}
						else
						{
							sKey +=  idx.ToString("D2");
						}
					}

					if (Dem.bCompInp.Enabled)
						sb += "Gate's Key " + sKey + "\r\n";

					alGates.Add(scWouldBeGate1);

					SortedList slInputs1 = new SortedList(); //The sorted list of the inputs for this wouldbe gate
					SortedList slInputs2 = new SortedList(); //The loosely coupled inputs belonging to an 'OR' gate
					ArrayList inputs = orientation == Orientations.Vertical ? 
						scWouldBeGate1.getAdjCellsByRowCol() : scWouldBeGate1.getAdjCellsByColRow();
					bool bFirstInput = true;
					int  cntLooseAnds = 0;
					//For all the inputs for this wouldbe gate
					foreach(ShadowCell input in inputs)
					{
						//IF: [The cell is still covered] and [it is unknown]
						if (input.getDisplay() == 'C' && input.getState() == ShadowCell.CurState.Unknown)
						{
							int iKey = 0;
							//IF: [orientation is Horizontal] then [the key is Oriented Vertically]
							if (orientation == CompositeInput.Orientations.Horizontal)
								iKey = input.getPos().ToIndexRowCol();
							else
								iKey = input.getPos().ToIndexColRow();

							Input aInput = null;
							//If [this is one of the tightly coupled inputs]
							if ((idx = alSharedInputs.IndexOf(input)) != -1)
							{
								iKey += int.Parse(idx.ToString() + iKey.ToString("D7"));
								aInput = (Input)slCoupledInputs.GetByIndex(idx);
								bFirstInput = false;
							}
							else
							{
								//IF: [this is an "OR" gate]
								if (myGate.myOperator == Gate.Operators.Or)
								{
									iKey += int.Parse("99" + iKey.ToString("D7"));
								}
								else
								{
									iKey += int.Parse("99" + iKey.ToString("D7"));
									//If [this is the first gate]
									if (bFirstInput==true)
									{
										iKey *= -1;
									}
									//If [more than one loose ands] 
									if ( ++cntLooseAnds > 1 )
										throw (new ApplicationException("And some sort of loosely coupled logic error." ));
								}
								//If [This is not one of the coupled inputs]
								if (aInput == null)
									aInput = new Input(input, myGate, this);
								//IF: [this is an "OR" gate]
								if (myGate.myOperator == Gate.Operators.Or)
								{
									aInput.index = iKey;
									slInputs2.Add(iKey,aInput);
									//If [we don't already have this input]
									if (slCoupledCompositeInputs.Contains(iKey) == false)
										slCoupledCompositeInputs.Add(iKey,aInput);
									continue;
								}
							}

							//If [already have this input]
							if (slCoupledCompositeInputs.Contains(iKey))
							{
								aInput = (Input)(slCoupledCompositeInputs.GetByIndex(slCoupledCompositeInputs.IndexOfKey(iKey)));
								aInput.AddOwner(myGate);
								aInput.index = iKey;
								slInputs1.Add(iKey,aInput);
								if (Dem.bCompInp.Enabled)
									sb += " Input Key " + iKey.ToString("D9") + " row "  + input.getPos().GetRow() + " col " + input.getPos().GetCol() + 
										" Adding owner " + myGate.sc.getPos().GetRow() + " col " + myGate.sc.getPos().GetCol() + "\r\n";
							}
							else
							{
								if (aInput == null)
									aInput = new Input(input, myGate, this);
								aInput.index = iKey;
								slCoupledCompositeInputs.Add(iKey,aInput);
								slInputs1.Add(iKey,aInput);

								if (Dem.bCompInp.Enabled)
									sb += " Input Key " + iKey.ToString("D9") + " row " + input.getPos().GetRow() + " col " + input.getPos().GetCol() + "\r\n";
							}
						}
					}

					//For the list of sorted inputs
					foreach(DictionaryEntry iDic1 in slInputs1)
					{
						Input input = ((Input)iDic1.Value);
						idx = slInputs1.IndexOfKey(iDic1.Key);
						myGate.tciputs.Add(idx);

						//IF: [this is an 'AND' gate]
						if (myGate.myOperator == Gate.Operators.And)
						{
							switch (iCnt)
							{
								case 0:
									((InputSet)myGate.arInputSets.GetValue(0)).slInputs.Add(idx, input);
									((InputSet)myGate.arInputSets.GetValue(2)).slInputs.Add(idx, input);
									break;
								case 1:
									((InputSet)myGate.arInputSets.GetValue(0)).slInputs.Add(idx, input);
									((InputSet)myGate.arInputSets.GetValue(1)).slInputs.Add(idx, input);
									break;
								case 2:
									((InputSet)myGate.arInputSets.GetValue(1)).slInputs.Add(idx, input);
									((InputSet)myGate.arInputSets.GetValue(2)).slInputs.Add(idx, input);
									break;
							}
						}
						else
							((InputSet)myGate.arInputSets.GetValue(0)).slInputs.Add(idx, input);

						myGate.arInputs.SetValue(input, iCnt++);
					}

					//If [This is an 'AND' gate]
					if (myGate.myOperator == Gate.Operators.And)
					{
						int cntInp =((InputSet)myGate.arInputSets.GetValue(0)).slInputs.Count + 
							((InputSet)myGate.arInputSets.GetValue(1)).slInputs.Count +
							((InputSet)myGate.arInputSets.GetValue(2)).slInputs.Count; 
						//If [we do not have all the inputs]
						if (cntInp != 6)
							throw (new ApplicationException("And gate does not have all it's inputs." ));
					}

					//If [This is an 'OR' gate]
					if (myGate.myOperator == Gate.Operators.Or)
						((InputSet)myGate.arInputSets.GetValue(1)).slInputs = slInputs2;

					sb += "Count of loosely coupled inputs" + slInputs2.Count + "\r\n";
					foreach(DictionaryEntry iDic2 in slInputs2)
					{
						Input input = (Input)iDic2.Value;
						sb += "  Loosely coupled input row " + input.sc.getPos().GetRow() + 
							" col " + input.sc.getPos().GetCol() + "\r\n";
					}

					//If [The gate is not already expressed] (drops duplications)
					if (slGates.ContainsKey(sKey) == false)
						slGates.Add(sKey,myGate);

					lastGate = myGate;
				}
				else
				{
					if (Dem.bCompInp.Enabled)
						sb += "*** This gate is not tightly coupled ***\r\n";
					continue;
				}
			}

			string stmp3 = "Deduce inputs with the logic of 'Not OR';'NOT And' and 'Compound ANDS'";
			if (Dem.bCompInp.Enabled) sb += stmp3 + "\r\n";
			if (Dem.bTraceDeep.Enabled) System.Diagnostics.Trace.WriteLine(stmp3);

			idx=-1;
			//For all the gates that have a unique set of tightly coupled inputs
			foreach(DictionaryEntry Dict in slGates)
			{
				idx++;
				Gate myGate = (Gate)Dict.Value;
				string stmp4 = "Solving for Gate Row " + myGate.sc.getPos().GetRow() + " Col " + myGate.sc.getPos().GetCol();
				if (Dem.bTraceDeep.Enabled)	System.Diagnostics.Trace.WriteLine(stmp4);
				if (Dem.bCompInp.Enabled)sb += stmp4 + "\r\n";

				//If [the gate has not been solved]
				if (myGate.IsSolved == false)
				{
					//If [this is an OR]
					if (myGate.myOperator == Gate.Operators.Or)
					{
						int cntOfInputs = ((InputSet)myGate.arInputSets.GetValue(0)).slInputs.Count;
						cntOfInputs += ((InputSet)myGate.arInputSets.GetValue(1)).slInputs.Count;
						//If [this could be a subset]
						if (((InputSet)myGate.arInputSets.GetValue(1)).slInputs.Count == 0)
						{
							Gate gtp = null;
							Gate gtl = null;
							string sKeyp = "";
							string sKeyl = "";
							string sKey = (string)slGates.GetKey(idx);
							//If [there is a previous gate]
							if (idx>0)
							{
								//If: [They are tightly coupled]
								if (AreGatesCoupled(slGates,idx-1,idx) == true)
								{
									gtp = (Gate)slGates.GetByIndex(idx-1);
									sKeyp = (string)slGates.GetKey(idx-1);
								}
							}
							//If [there is a latter gate]
							if (idx+1 < slGates.Count)
							{
								
								//If: [They are tightly coupled]
								if (AreGatesCoupled(slGates,idx,idx+1) == true)
								{
									gtl = (Gate)slGates.GetByIndex(idx+1);
									sKeyl = (string)slGates.GetKey(idx+1);
								}
							}

							//If [there is a previous gate]
							if (gtp != null)
							{
								//If [the previous gate is an OR]
								if (gtp.myOperator == Gate.Operators.Or)
								{
									if (Dem.bTraceDeep.Enabled)
										System.Diagnostics.Trace.WriteLine("Previous OR");
									if (Dem.bCompInp.Enabled)
										sb += "Previous OR \r\n";
									//If [this is a subset]
									if ( sKeyp.EndsWith(sKey) == true )
									{
										// Find the union of the sets
										int ofs = sKeyp.IndexOf(sKey); 
										//If [found the offset of the subset]
										if (ofs != -1)
										{
											int cnt = ofs/3;
											for(int idy=0; idy < cnt; idy++)
											{
												int i = int.Parse(sKeyp.Substring(idy*3,2));
												Input.states inpState = Input.states.unknown;
												string sinpState = "unknown";
												//If [the previous gate is an OR]
												if (gtp.myOperator == Gate.Operators.Or)
												{
													inpState = Input.states.off;
													sinpState = " off ";
												}
												else
												{
													inpState = Input.states.on;
													sinpState = " on ";
												}

												if (Dem.bTraceDeep.Enabled)
													System.Diagnostics.Trace.WriteLine("Set previous input " + i + sinpState);
												if (Dem.bCompInp.Enabled)
													sb += "Set previous input " + i + sinpState + "\r\n";
												((Input)slCoupledInputs.GetByIndex(i)).state = inpState; 
												//If [the composite input is solved]
												if (Solved() == true)
													break;
											}
										}
									}
								}	
							}

							//If [there is a latter gate]
							if (gtl != null)
							{
								//If [the latter gate is an OR]
								if (gtl.myOperator == Gate.Operators.Or)
								{
									//If [this gate is a subset of the next gate]
									if (sKeyl.StartsWith(sKey) == true )
									{
										if (Dem.bTraceDeep.Enabled)
											System.Diagnostics.Trace.WriteLine("Latter OR");
										if (Dem.bCompInp.Enabled)
											sb +=  "Latter OR \r\n";
										int dif = sKeyl.Length - sKey.Length; 
										int cnt = (dif)/3;
										int org = (sKeyl.Length-dif+1)/3;
										for(int idy=org; idy < org+cnt; idy++ )
										{
											int i = int.Parse(sKeyl.Substring(idy*3,2));
											Input.states inpState = Input.states.unknown;
											string sinpState = "unknown";
											//If [the latter gate is an OR]
											if (gtl.myOperator == Gate.Operators.Or)
											{
												inpState = Input.states.off;
												sinpState = " off ";
											}
											else
											{
												inpState = Input.states.on;
												sinpState = " on ";
											}

											if (Dem.bTraceDeep.Enabled)
												System.Diagnostics.Trace.WriteLine("set latter input " + idy + sinpState);
											if (Dem.bCompInp.Enabled)
												sb += "set latter input " + idy + sinpState + "\r\n";
											((Input)slCoupledInputs.GetByIndex(idy)).state = inpState; 
											//If [the composite input is solved]
											if (Solved() == true)
												break;
										}
									}
								}	
							}
						}
					}


					//If [this is an AND gate]
					if (myGate.myOperator == Gate.Operators.And)
					{
						Gate gtp = null;
						Gate gtl = null;
						//If [there is a previous gate]
						if (idx>0)
						{
							//If: [They are tightly coupled]
							if ( AreGatesCoupled(slGates,idx-1,idx) == true )
							{
								gtp = (Gate)slGates.GetByIndex(idx-1);
							}
						}
						//If [there is a latter gate]
						if (idx+1 < slGates.Count)
						{
							//If: [They are tightly coupled]
							if (AreGatesCoupled(slGates,idx,idx+1) == true)
							{
								gtl = (Gate)slGates.GetByIndex(idx+1);
							}
						}

						int cnt=3;
						//If [there is a previous gate]
						if (gtp != null)
						{
							//If [the previous gate is an OR]
							if (gtp.myOperator == Gate.Operators.Or)
							{
								if (Dem.bTraceDeep.Enabled)
									System.Diagnostics.Trace.WriteLine("And wt previous OR");
								if (Dem.bCompInp.Enabled)
									sb += "And wt previous OR\r\n";
								//Reduce the first AND
								((InputSet)myGate.arInputSets.GetValue(0)).State = InputSet.States.Removed;
								cnt--;
							}	
						}

						//If [there is a latter gate]
						if (gtl != null)
						{
							//If [the latter gate is an OR]
							if (gtl.myOperator == Gate.Operators.Or)
							{
								if (Dem.bTraceDeep.Enabled)
									System.Diagnostics.Trace.WriteLine("And wt latter OR");
								if (Dem.bCompInp.Enabled)
									sb += "And wt latter OR\r\n";
								//Reduce the last AND
								((InputSet)myGate.arInputSets.GetValue(1)).State = InputSet.States.Removed;
								cnt--;
							}	
						}

						//If [there is a prevous gate]
						if (gtp != null)
						{
							//If [the prevous gate is an AND]
							if (gtp.myOperator == Gate.Operators.And)
							{
								if (Dem.bCompInp.Enabled)
									sb += "And wt prevous And \r\n";
								cnt = 0;
								int idy = 0;
								foreach(InputSet ipSet in myGate.arInputSets)
								{
									//If [This input set is Removed]
									if (ipSet.State == InputSet.States.Removed)
									{
										int x = Gate.unionsOfAndPrv[idy];
										((InputSet)gtp.arInputSets.GetValue(x)).State = InputSet.States.Removed;
										if (Dem.bCompInp.Enabled)
											sb += "    removing linked input sets " + idy + " U "  + x + "\r\n";
									}
									else
										cnt++;
									idy++;
								}
							}
						}

						//If [there is a latter gate]
						if (gtl != null)
						{
							//If [the latter gate is an AND]
							if (gtl.myOperator == Gate.Operators.And)
							{
								cnt = 0;
								int idy = 0;
								foreach(InputSet ipSet in myGate.arInputSets)
								{
									if (Dem.bCompInp.Enabled)
										sb += "And wt latter And\r\n";
									//If [This input set is Removed]
									if (ipSet.State == InputSet.States.Removed)
									{
										int x = Gate.unionsOfAndLtr[idy];
										((InputSet)gtl.arInputSets.GetValue(x)).State = InputSet.States.Removed;
										if (Dem.bCompInp.Enabled)
											sb += "    removing linked input sets " + idy + " U "  + x + "\r\n";
									}
									else
										cnt++;
									idy++;
								}
							}
						}

						//If [We solved this gate]
						if (cnt == 1)
						{
							InputSet ipSet = null;
							foreach(InputSet ipSet2 in  myGate.arInputSets)
							{
								//If [This is the set that was not removed]
								if (ipSet2.State != InputSet.States.Removed)
								{
									ipSet = ipSet2;
									break;
								}
							}

							// Set the Inputs
							foreach(DictionaryEntry iDic  in ipSet.slInputs)
							{
								Input iPut2 = (Input)iDic.Value;
								if (Dem.bTraceDeep.Enabled)
									System.Diagnostics.Trace.WriteLine("And setting input " + iPut2.index + " on" );
								if (Dem.bCompInp.Enabled)
									sb += "And setting input index " + iPut2.index + " row " + iPut2.sc.getPos().GetRow() + 
										" col " + iPut2.sc.getPos().GetCol() + " on\r\n"; 
								iPut2.state = Input.states.on;
								//If [the composite input is solved]
								if (Solved() == true)
									break;
							}
						}
					}
				}
			}

			//If [We have any solved inputs to display]
			if (SolvedInputs.Count > 0)
			{
				if (Dem.bCompInp.Enabled)
					sb += "Solution of Inputs\r\n";
				if (Dem.bTraceDeep.Enabled)
					System.Diagnostics.Trace.WriteLine("Solution of Inputs\r\n");
				if (Dem.bCompInp.Enabled || Dem.bTraceDeep.Enabled)
				{
					foreach(DictionaryEntry iDic in slCoupledCompositeInputs)
					{
						Input input = ((Input)iDic.Value);
						string state = "";
						switch(input.state)
						{
							case Input.states.off:
								state = " off ";
								break;
							case Input.states.on:
								state = " on ";
								break;
							case Input.states.unknown:
								state = " unknown ";
								break;
						}
						if (Dem.bCompInp.Enabled)
							sb += "Input " + ((int)iDic.Key).ToString("D7") + " row " + input.sc.getPos().GetRow() + " col " + input.sc.getPos().GetCol() + 
								" is" + state + "\r\n"; 
						if (Dem.bTraceDeep.Enabled)
							System.Diagnostics.Trace.WriteLine("Input " + ((int)iDic.Key).ToString("D5") + " row " + input.sc.getPos().GetCol() + 
								" col " + input.sc.getPos().GetRow() + " is" + state + "\r\n");
					}
					foreach(DictionaryEntry iDic in slUnCoupledCompositeInputs)
					{
						Input input = ((Input)iDic.Value);
						string state = "";
						switch(input.state)
						{
							case Input.states.off:
								state = " off ";
								break;
							case Input.states.on:
								state = " on ";
								break;
							case Input.states.unknown:
								state = " unknown ";
								break;
						}
						if (Dem.bCompInp.Enabled)
							sb += "Input " + ((int)iDic.Key).ToString("D7") + " row " + input.sc.getPos().GetRow() + " col " + input.sc.getPos().GetCol() + 
								" is" + state + "\r\n"; 
						if (Dem.bTraceDeep.Enabled)
							System.Diagnostics.Trace.WriteLine("Input " + ((int)iDic.Key).ToString("D7") + " row " + input.sc.getPos().GetCol() + 
								" col " + input.sc.getPos().GetRow() + " is" + state + "\r\n");
					}
				}
				if (Dem.bCompInp.Enabled)
				{
					if (!File.Exists("C:\\minesweeper\\CompositeInput1.txt"))
						fs = File.Create("C:\\minesweeper\\CompositeInput1.txt");
					else
						fs = File.OpenWrite("C:\\minesweeper\\CompositeInput1.txt");
				}
			}
			else
			{
				if (Dem.bCompInp.Enabled)
				{
					if (!File.Exists("C:\\minesweeper\\CompositeInput2.txt"))
						fs = File.Create("C:\\minesweeper\\CompositeInput2.txt");
					else
						fs = File.OpenWrite("C:\\minesweeper\\CompositeInput2.txt");
				}
			}

			if (Dem.bCompInp.Enabled)
			{
				fs.Seek(0,SeekOrigin.End);
				sw = new StreamWriter( fs );
				sw.Write("\r\n\r\n" + System.DateTime.Now.ToString() + "\r\n");
				sw.Write("Game# " + Dem.iGameID + "\r\n");
				sw.Write("Guess# " + player.nbrOfGuesses + "\r\n");

				sw.Write(sb);
				sw.Close();
			}

		}

		/// <summary>
		/// Test two Input to see if they share at least one pair of Owners. If They share at least one pair. 
		/// They are considered to be tightly coupled.
		/// </summary>
		/// <param name="first">First Input</param>
		/// <param name="second">Second Input</param>
		/// <returns>true when inputs share a pair of owners</returns>
		private bool AreInputsCoupled(Input first, Input second)
		{
			int cnt=0;
			foreach(Gate gate in first.InpSetOwners)
			{
				//If [They share the owner]
				if (second.InpSetOwners.Contains(gate))
					cnt++;
				if (cnt>1)
					break;
			}
			return cnt>1;
		}

		/// <summary>
		/// Test two gates from the sortedlist to see if they share at least a pair of inputs
		/// </summary>
		/// <param name="slGates">Sorted List of Gates</param>
		/// <param name="first">First gate's index</param>
		/// <param name="second">Second gate's index</param>
		/// <returns></returns>
		private bool AreGatesCoupled(SortedList slGates, int first, int second)
		{

			//If: [They are tightly coupled]
			if (((string)slGates.GetKey(first)).EndsWith(((string)slGates.GetKey(second)).Substring(0,5)))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Find the covered inputs that the two gates share ordered by orientation
		/// </summary>
		/// <param name="scWouldBeGate1">The first gate to compare with</param>
		/// <param name="scWouldBeGate2">The second gate to compare against</param>
		/// <param name="orient">The orientation </param>
		/// <returns>Array of shared inputs ordered by orientation</returns>
		private ArrayList  FindSharedInputs(ShadowCell scWouldBeGate1,ShadowCell scWouldBeGate2,Orientations  orient)
		{
			ArrayList cInputs = new ArrayList();
			ArrayList inputs1 = 
				orientation == Orientations.Vertical ? scWouldBeGate1.getAdjCellsByRowCol() : 
					scWouldBeGate1.getAdjCellsByColRow();
			ArrayList inputs2 = 
				orientation == Orientations.Vertical ? scWouldBeGate2.getAdjCellsByRowCol() : 
					scWouldBeGate2.getAdjCellsByColRow();

			foreach(ShadowCell iPut1 in inputs1)
			{
				//IF: [The cell is still covered] and [it is unknown]
				if (iPut1.getDisplay() == 'C' && iPut1.getState() == ShadowCell.CurState.Unknown)
				{
					//If [We find a matching set of inputs]
					if (inputs2.Contains(iPut1)==true)
					{
						cInputs.Add(iPut1);
					}
				}
			}
			return cInputs;
		}



	}

	/// <summary>
	/// Pos of the cell in Row and Column.
	/// The position are all translated to ones based indexing
	/// to accommodate the math.
	/// </summary>
	class Pos 
	{
		/// <summary>
		/// Cells Row or relative Y axis (1-n)
		/// </summary>
		int Row; 
		/// <summary>
		/// Cells Columns or relative X axis (1-n)
		/// </summary>
		int Col; 
        
		/// <summary>
		/// Create a position given the absolute Row and Column 
		/// </summary>
		/// <param name="C">Column</param>
		/// <param name="R">Row</param>
		public Pos(int C, int R) 
		{
			Row = R;
			Col = C;
		}
        
		/// <summary>
		/// Create a position given the zero base index of cells that is based on Row and Column order 
		/// </summary>
		/// <param name="idx">index of the cell</param>
		public Pos(int idx)
		{
			Row = idx/(Dem.iTotCols)+1; // Row from Cells index
			Col = idx%(Dem.iTotCols)+1; // Col From Cells index
		}

		/// <summary>
		/// Returns the zero base index for the cell by Row and Column 
		/// </summary>
		/// <returns>Index of this cell (Horizontal)</returns>
		public int ToIndexRowCol()
		{
			return ((Row-1) * Dem.iTotCols)+(Col-1);
		}

		/// <summary>
		/// Returns the zero base index for the cell by Column and Row 
		/// </summary>
		/// <returns>Index of this cell (Vertical)</returns>
		public int ToIndexColRow()
		{
			return ((Col-1) * Dem.iTotRows)+(Row-1);
		}

		/// <summary>
		/// Returns the Row 
		/// </summary>
		/// <returns></returns>
		public int GetRow()
		{
			return Row;
		}

		/// <summary>
		/// Returns the Column 
		/// </summary>
		/// <returns></returns>
		public int GetCol()
		{
			return Col;
		}

	}

	/// <summary>
	/// Is used to keep trackof the status of the cells in the game.
	/// </summary>
	class ShadowCell 
	{
		/// <summary>
		/// orientation in the matrix
		/// </summary>
		public enum Orientations { Vertical=0, Horizontal=2, Unknown=3 };
		/// <summary>
		/// The states of a cell
		/// </summary>
		public enum CurState : int { Nullified=0, Unknown=1, Bomb=2 };
		/// <summary>
		/// The array of shadowCells in order of row and column
		/// </summary>
		public static ArrayList shadowCellsRowCol = new ArrayList();
		/// <summary>
		/// The position of this cell in the matrix.
		/// </summary>
		Pos cPos; 
		/// <summary>
		/// true when all of the surrounding cells are known, and 
		/// helps to reduce the number of nested iterations we make 
		/// </summary>
		public bool isBombPlayedOut = false; 
		/// <summary>
		/// The number of cells whose state is known to be a bomb
		/// </summary>
		public int cntOfAdjBombs = 0;
		/// <summary>
		/// The number of adjacent cells whose state is unknown.
		/// </summary>
		private int cntOfAdjCvrdCells = 0; 
		/// <summary>
		/// The current state of this cell
		/// </summary>
		CurState State = CurState.Unknown;
		/// <summary>
		/// The display for this cell
		/// </summary>
		Char Display = 'C';
		/// <summary>
		/// This is the array of adjacent cells to this one ordered by Row and Column. 
		/// </summary>
		ArrayList adjCellsRowCol;
		/// <summary>
		/// This is the array of adjacent cells to this one ordered by Column and Row. 
		/// </summary>
		ArrayList adjCellsColRow;
		/// <summary>
		/// The temporary list of potential threats this cell is associated with
		/// </summary>
		public ArrayList bombPotentials; // The set bomb potentialy for this cell.

		/// <summary>
		/// Create a reference to the cell at the given index  
		/// </summary>
		/// <param name="idx"></param>
		public ShadowCell(int idx)
		{
			cPos = new Pos(idx);
			adjCellsRowCol = new ArrayList();
			adjCellsColRow = new ArrayList();
		}
        
		/// <summary>
		/// Decrements the number of covered cells.
		/// </summary>
		private void decAdjCoveredCells() 
		{
			cntOfAdjCvrdCells--;
		}

		/// <summary>
		/// Builds the list of adjacent squares to this one
		/// </summary>
		public void hookAdjCells() 
		{
			try 
			{
				//IF [there is a row above this one]
				if (this.cPos.GetRow() > 1) 
				{
					//IF [there is a cell before this one]
					if (this.cPos.GetCol() > 1) 
					{
						adjCellsRowCol.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()-1,this.cPos.GetRow()-1).ToIndexRowCol()]);
					}
					adjCellsRowCol.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol(),this.cPos.GetRow()-1).ToIndexRowCol()]);
					//IF [there is a cell after this one]
					if (this.cPos.GetCol() < Dem.iTotCols) 
					{
						adjCellsRowCol.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()+1,this.cPos.GetRow()-1).ToIndexRowCol()]);
					}
				}
				//IF [there is a cell before this one]
				if (this.cPos.GetCol() > 1) 
				{
					adjCellsRowCol.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()-1,this.cPos.GetRow()).ToIndexRowCol()]);
				}
				//IF [there is a cell after this one]
				if (this.cPos.GetCol() < Dem.iTotCols) 
				{
					adjCellsRowCol.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()+1,this.cPos.GetRow()).ToIndexRowCol()]);
				}
				//IF [there is a row below this one]
				if (this.cPos.GetRow() < Dem.iTotRows) 
				{
					//IF [there is a cell before this one]
					if (this.cPos.GetCol() > 1) 
					{
						adjCellsRowCol.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()-1,this.cPos.GetRow()+1).ToIndexRowCol()]);
					}
					adjCellsRowCol.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol(),this.cPos.GetRow()+1).ToIndexRowCol()]);
					//IF [there is a cell after this one]
					if (this.cPos.GetCol() < Dem.iTotCols) 
					{
						adjCellsRowCol.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()+1,this.cPos.GetRow()+1).ToIndexRowCol()]);
					}
				}
			} 
			catch(Exception e) 
			{
				throw (new ApplicationException("Exception error: Shadow cell " + e.Message));
			}

			cntOfAdjCvrdCells = adjCellsRowCol.Count;

			//If [there is a column before this one]
			if (this.cPos.GetCol() > 1)
			{
				//If [there is a row before this one]
				if (this.cPos.GetRow() > 1)
					adjCellsColRow.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()-1,this.cPos.GetRow()-1).ToIndexRowCol()]);
				adjCellsColRow.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()-1,this.cPos.GetRow()).ToIndexRowCol()]);
				//If [there is a row below]
				if (this.cPos.GetRow() < Dem.iTotRows)
					adjCellsColRow.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()-1,this.cPos.GetRow()+1).ToIndexRowCol()]);
			}
			//IF [there is a cell above this one]
			if (this.cPos.GetRow() > 1) 
			{
				adjCellsColRow.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol(),this.cPos.GetRow()-1).ToIndexRowCol()]);
			}
			//IF [there is a cell below this one]
			if (this.cPos.GetRow() < Dem.iTotRows) 
			{
				adjCellsColRow.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol(),this.cPos.GetRow()+1).ToIndexRowCol()]);
			}
			//IF [there is a Column after this one]
			if (this.cPos.GetCol() < Dem.iTotCols) 
			{
				//IF [there is a row above this one]
				if (this.cPos.GetRow() > 1) 
				{
					adjCellsColRow.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()+1,this.cPos.GetRow()-1).ToIndexRowCol()]);
				}
				adjCellsColRow.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()+1,this.cPos.GetRow()).ToIndexRowCol()]);
				//IF [there is a Row below this one]
				if (this.cPos.GetRow() < Dem.iTotRows) 
				{
					adjCellsColRow.Add(shadowCellsRowCol[new Pos(this.cPos.GetCol()+1,this.cPos.GetRow()+1).ToIndexRowCol()]);
				}
			}
		}

		/// <summary>
		/// Increment the count of adjacent bombs to me 
		/// </summary>
		private void incAdjBombs() 
		{
			cntOfAdjBombs++;
		}

		/// <summary>
		/// Checks to see if two inputs share at lease two gates, while collecting the tightly 
		/// coupled.
		/// </summary>
		/// <param name="inp1">input one</param>
		/// <param name="inp2">input two</param>
		/// <param name="cGates">The references to the array of coupled gates</param>
		/// <param name="Orentation">The orientation of the gates</param>
		/// <returns>true when the inputs share two or more gates</returns>
		public bool isTightlyCoupled(ShadowCell inp1, ShadowCell inp2, ref SortedList cGates, ShadowCell.Orientations Orentation)
		{
			SortedList tmp = new SortedList();
			int cnt = 0; // count of matching gates 
			//Find at lease two inputs that are common
			foreach(ShadowCell gate2 in inp2.adjCellsRowCol)
			{
				//If [This is a gate]
				if (Char.IsDigit(gate2.Display) == true)
					//IF [We have matching gates]
					if (inp1.adjCellsRowCol.Contains(gate2))
					{
						cnt++;
						int key = -1;
						//If [the inputs are aligned Horizontal]
						if (Orentation == Orientations.Horizontal)
							key = gate2.getPos().ToIndexColRow();
						else
							key = gate2.getPos().ToIndexRowCol();
						//If [we don't have this one]
						if (cGates.ContainsKey(key) == false)
							tmp.Add(key, gate2);
					}
			}
			//If [they are tightly coupled]
			if (cnt > 1)
				foreach(DictionaryEntry iDic in tmp)
					cGates.Add(iDic.Key,iDic.Value);

			return cnt > 1;
		}

		/// <summary>
		/// Sets the display value and will
		/// throw a logic error to indicate an error from game server or we have a bomb showing 
		/// </summary>
		/// <param name="c">the charactor of the display</param>
		public void setDisplay(char c)
		{
			//IF: [There was a change]
			if (Display != c)
			{
				//IF: [it is not a numeric value] then [Error]
				if (!Char.IsNumber(c))
				{
					// Commented so I can get the feedback when I lose.
//					throw (new ApplicationException("Logic Error: Cell contains a bomb, oops."));
					Display = c; // Debugging only
				}
				else
				{
					// This event will only occur once per cell.
					Display = c; 
					//For all the adjacent cells 
					foreach(ShadowCell sc in getAdjCells())
						sc.decAdjCoveredCells();

					//IF: [The display element is zero] Then [There are no adjacent bombs]
					if (UInt16.Parse(Char.ToString(c)) == 0) 
					{
						State = CurState.Nullified; // This is a given Don't care (based on the game)
					}
				}
			}
		}

		/// <summary>
		/// Returns the count of adjacent cells that have a state of bomb
		/// </summary>
		/// <returns>count adjacent cells with a state of being a bomb</returns>
		public int getCountOfAdjBombs()
		{
			return cntOfAdjBombs;
		}

		/// <summary>
		/// Returns the count of adjacent cells that have a state of unknown.
		/// </summary>
		/// <returns>Count of adjacent covered cells</returns>
		public int getCountOfAdjCoveredCells()
		{
			return cntOfAdjCvrdCells;
		}

		/// <summary>
		/// Return the state of the display
		/// </summary>
		/// <returns>Character from Display</returns>
		public char getDisplay()
		{
			return Display;
		}

		/// <summary>
		/// Returns the current state of this cell
		/// </summary>
		/// <returns>ShadowCell.CurState State</returns>
		public CurState getState()
		{
			return State;
		}

		/// <summary>
		/// Sets the state of the cell; 
		/// decrements the number of adjacent covered cells and increments the number of bombs. 
		/// </summary>
		/// <param name="CS">ShadowCell.CurState</param>
		public void setState(CurState CS)
		{
			if (State == ShadowCell.CurState.Unknown)
			{
				State = CS;
				switch (State)
				{
					case ShadowCell.CurState.Bomb:
						if (Dem.bTraceDeep.Enabled)
							System.Diagnostics.Trace.WriteLine("Cell is bomb at row "  +  this.getPos().GetRow() + " col. " + this.getPos().GetCol());
						Dem.arrShadowBombs.Add(this); // Add the bomb to our shadow bomb array.
						foreach(ShadowCell sc in getAdjCells())
						{
							sc.decAdjCoveredCells();
							sc.incAdjBombs();
						}
						break;
					case ShadowCell.CurState.Nullified: 
						if (Dem.bTraceDeep.Enabled)
							System.Diagnostics.Trace.WriteLine("Cell is neutralized at row "  +  this.getPos().GetRow() + " col. " + this.getPos().GetCol());
						break;
					case ShadowCell.CurState.Unknown:
						throw ( new Exception("setState to Unknown not allowed"));
				}
			}
			else
			{
				//IF [I am getting conflicting states]
				if (State != CS)
					throw( new Exception("ShadowCell setState getting conflicting states."));
			}
		}

		/// <summary>
		/// Gets the position of the cell as an index ordered by row and column 
		/// </summary>
		/// <returns>Index (Horizontal)</returns>
		public int getPosAsIndexRowCol() 
		{
			return cPos.ToIndexRowCol();
		}

		/// <summary>
		/// Gets the position of the cell as an index ordered by column and row. 
		/// </summary>
		/// <returns>Index (Vertical)</returns>
		public int getPosAsIndexColRow() 
		{
			return cPos.ToIndexColRow();
		}

		/// <summary>
		/// Gets the position of the cell as a Pos object
		/// </summary>
		/// <returns>Pos object</returns>
		public Pos getPos()
		{
			return cPos;
		}

		/// <summary>
		/// Gets the cells calculated value by subtracting it's display value from the number of adjacent bombs discovered.
		/// </summary>
		/// <returns>Adjusted value for the display</returns>
		public int getCalculatedValue() 
		{
			//IF: [Display is not a value]
			if (!Char.IsDigit(Display))
				throw (new ApplicationException("Logic Error: getCalculatedValue is not a digit."));

			return int.Parse(Display.ToString()) - cntOfAdjBombs;
		}

		/// <summary>
		/// Gets the array of adjacent cells ordered by row and column 
		/// </summary>
		/// <returns>List of adjacent cells (Horizontal)</returns>
		public ArrayList getAdjCells() 
		{
			return adjCellsRowCol;
		}

		/// <summary>
		/// Gets the array of adjacent cells ordered by row and column.
		/// This is the same as getadjCells and is defined for clarity only.  
		/// </summary>
		/// <returns>List of adjacent cells (Vertical)</returns>
		public ArrayList getAdjCellsByRowCol() 
		{
			return adjCellsRowCol;
		}
		
		/// <summary>
		/// Gets the array of adjacent cells ordered by column and row. 
		/// </summary>
		/// <returns></returns>
		public ArrayList getAdjCellsByColRow() 
		{
			return adjCellsColRow;
		}
	}



	/// <summary>
	/// MyTraceListener forwards tracing messages from the Mindsweep Dll to the textbox 
	/// class passes to it in its constructor.
	/// </summary>
	class MyTraceListener : TraceListener
	{
		System.IO.MemoryStream ms;
		System.IO.StreamWriter swr;
		ArrayList TBoxes;

		public MyTraceListener(ArrayList TBA) : base()
		{
			ms = new System.IO.MemoryStream(1024);
			swr = new System.IO.StreamWriter(ms);
			TBoxes = TBA;
		}

		public override void Write(string msg)
		{
			foreach(System.Windows.Forms.TextBox textbox in TBoxes)
			{
				if (msg.Split(':').Length > 0)
				{
					textbox.Text = msg.Split(':')[0].ToString();
					textbox.Invalidate();
				}
			}
		}
		public override void WriteLine(string msg)
		{
			foreach(System.Windows.Forms.TextBox textbox in TBoxes)
			{
				if (msg.Split(':').Length > 0)
				{
					textbox.Text = msg.Split(':')[0].ToString();
					textbox.Invalidate();
				}
			}
		}

	}

}



