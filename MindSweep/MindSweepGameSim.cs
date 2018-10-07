/*
 * Project: MindSweep 
 * 
 * File: Class1.cs
 *
 * Minesweeper interface and emulator for the purposes of testing a polynomal solution to the game.
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
using System.Collections;
using System.Windows.Forms;

//using System;
using System.Threading;
using System.Runtime;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Lifetime;
using System.IO;
using System.Security.Cryptography;



namespace MindSweep
{

	/// <summary>
	///  Tracing Display Targets
	///  Each string represents the name of a control on the display screen where the  
	///  trace message is to be sent.
	/// </summary>
	public class TrcDf
	{
		internal static string Status = "StatusBox:";	// General status messages.
		internal static string SubStatus = "SubStatusBox:"; // General sub-status message.
		internal static string State = "StateBox:"; // State of the current game.
		internal static string CellsTot = "CellsTotBox:"; // Number of Cells in the current game.
		internal static string BombsTot = "BombsTotBox:"; // Number of Bombs in the current game.
		internal static string Wins = "WinsBox:"; // The number of times the player has won.
		internal static string Losses = "LossesBox:"; // The number of times the player has lost.
		internal static string Remaining = "RemainingBox:"; // The number of cells the player has to uncover yet.
		internal static string AutoUnv = "AutoUnvBox:"; // The number of cells neutralized automatically.
	}

	/// <summary>
	/// Creates the instance of the game channel.
	/// </summary>
	public class MindSweepChannel
	{
		public MindSweepChannel(int Channel)
		{
			TcpServerChannel tcpservchannel = new 
				TcpServerChannel(Channel);
			ChannelServices.RegisterChannel(tcpservchannel, true);
			RemotingConfiguration.ApplicationName = "MindSweep";
			RemotingConfiguration.RegisterActivatedServiceType
				(typeof(Game));
		}
	}

	/// <summary>
	/// States that the game can be in:
	/// </summary>
	public enum State : int { Limbo=0, Playing=1, Won=2, Lost=3 };

	/// <summary>
	/// The Games Boards Level Internal Global Definitions. 
	/// </summary>
	class Dem 
	{
		internal static int iGame    = 0;
		internal static int iTotRows = 1000; // The total number of rows
		internal static int iTotCols = 1000; // The total number of columns
		internal static int iTotBoms = (int)(iTotRows*iTotCols*0.10); // The total numbers of bombs

		internal static MindSweep.State State = State.Limbo;

		internal static int iTotWins = 0; // Total number of times the player has won
		internal static int iTotLosses = 0; // Total number of times the player has lost
		internal static int iCellsUnv = 0; // Total number of cells uncovered
		internal static int iAutoUnv = 0; // Number of cells uncovered automatically

	}

	/// <summary>
	/// Game Interface
	/// </summary>
	public class Game : MarshalByRefObject
	{
		internal BooleanSwitch bDump = new BooleanSwitch("Dump", "SwpSolution Dump");

		/// <summary>
		/// Game Constructor
		/// </summary>
		public Game()
		{
			Dem.State = State.Limbo;
			System.Diagnostics.Trace.WriteLine( TrcDf.State + "Limbo");
		}

		/// <summary>
		/// Dumps the board and the state of play to disk
		/// </summary>
		public void dump()
		{
			if (bDump.Enabled == true)
			{
				Stream myFile = null;
				char[] board1 = getBoard();
				char[] board2 = getDisplay();
				System.IO.Directory.CreateDirectory("C:\\minesweeper");
				myFile = File.Create("C:\\minesweeper\\Dump" + Dem.iGame + ".txt");
				//If [we are in the midle of a game]
				if (Dem.State == State.Lost)
				{
					for(int x=0; x<Dem.iTotRows; x++)
					{
						byte[] tmp = new byte[Dem.iTotCols];
						for(int y=0; y<Dem.iTotCols; y++)
							//If [this has a bomb]
							if ((byte)board2[x*Dem.iTotCols+y] == 'B')
								tmp[y] = (byte)board2[x*Dem.iTotCols+y];
							else
								tmp[y] = (byte)board1[x*Dem.iTotCols+y];
						myFile.Write(tmp,0,Dem.iTotCols);
						myFile.Write(new byte[]{(byte)'\r',(byte)'\n'},0,2);
					}
					myFile.Write(new byte[]{(byte)'\r',(byte)'\n'},0,2);
					for(int x=0; x<Dem.iTotRows; x++)
					{
						byte[] tmp = new byte[Dem.iTotCols];
						for(int y=0; y<Dem.iTotCols; y++)
							tmp[y] = (byte)board2[x*Dem.iTotCols+y];
						myFile.Write(tmp,0,Dem.iTotCols);
						myFile.Write(new byte[]{(byte)'\r',(byte)'\n'},0,2);
					}
				}
				myFile.Close();
			}
		}

		/// <summary>
		/// System stuff
		/// </summary>
		/// <returns></returns>
		public override Object InitializeLifetimeService()
		{
			ILease lease = (ILease)base.InitializeLifetimeService();
			if (lease.CurrentState == LeaseState.Initial)  
			{
				lease.InitialLeaseTime = TimeSpan.FromMinutes(10);
				lease.SponsorshipTimeout = TimeSpan.FromMinutes(10);
				lease.RenewOnCallTime = TimeSpan.FromSeconds(60*15);
			}
			return lease;
		}

		/// <summary>
		/// Beging a new game
		/// </summary>
		public void Start()
		{
			Dem.iGame++;
			// Display Info.
			Dem.State = State.Limbo;
			System.Diagnostics.Trace.WriteLine( TrcDf.State + "Limbo");
			System.Diagnostics.Trace.WriteLine( TrcDf.CellsTot + Dem.iTotCols*Dem.iTotRows);
			System.Diagnostics.Trace.WriteLine( TrcDf.BombsTot + Dem.iTotBoms );
			System.Diagnostics.Trace.WriteLine( TrcDf.Wins + Dem.iTotWins );
			System.Diagnostics.Trace.WriteLine( TrcDf.Losses + Dem.iTotLosses );
			System.Diagnostics.Trace.WriteLine( TrcDf.Remaining + (Dem.iTotCols*Dem.iTotRows-Dem.iTotBoms));
			Dem.iCellsUnv = 0;
			Dem.iAutoUnv = 0;

			Cell.Cells = new ArrayList();

			System.Diagnostics.Trace.WriteLine( TrcDf.Status + "Creating cells matrix");

			// Create the cell matrix
			for(int x = 0; x<Dem.iTotCols*Dem.iTotRows; x++)
				Cell.Cells.Add(new Cell(x));

			ArrayList idxBombs = new ArrayList();

			System.Diagnostics.Trace.WriteLine(TrcDf.Status + "Adding bombs");
			int bc = 0;
			int i = 0;
			do 
			{
				int Rv = MyRand(Dem.iTotCols*Dem.iTotRows);
				//IF: [This cell is not already a bomb] Then [Set it as one]
				if (((Cell)Cell.Cells[Rv]).isBomb() == false)
				{
					((Cell)Cell.Cells[Rv]).setBomb(true);
					System.Diagnostics.Trace.WriteLine(TrcDf.SubStatus + "cnt = " + i++ + " To " + Dem.iTotBoms);
				}
				else
				{
					System.Diagnostics.Trace.WriteLine(TrcDf.Status + "DUP NUMBER " + ++bc );
				}
			} while(i < Dem.iTotBoms);

			System.Diagnostics.Trace.WriteLine(TrcDf.Status + "Setting up cells");
			for(int x = 0; x<Dem.iTotCols*Dem.iTotRows; x++)
				((Cell)Cell.Cells[x]).hookAdjCells();

			Dem.State = State.Playing;
			System.Diagnostics.Trace.WriteLine( TrcDf.State + "Playing");
		}

//		/// <summary>
//		/// This is only for testing purposes and will be commented out.
//		/// </summary>
//		/// <param name="col"></param>
//		/// <param name="row"></param>
//		/// <returns></returns>
//		public bool IsBomb(int col, int row)
//		{
//			Pos MyPos = new Pos(col,row);
//
//			return ((Cell)Cell.Cells[MyPos.ToIndex()]).isBomb();
//		}

		/// <summary>
		/// The cell the player has selected to uncover
		/// </summary>
		/// <param name="col">column of the cell to uncover</param>
		/// <param name="row">row of the cell to uncover</param>
		/// <returns>The state of the game</returns>
		public State select(int col, int row)
		{
			Pos MyPos = new Pos(col,row);

			System.Diagnostics.Trace.WriteLine(TrcDf.Status + "Player selecting cell at position Col:" + col + " Row: " + row + " idx:" +  MyPos.ToIndex());
			System.Diagnostics.Trace.WriteLine(TrcDf.SubStatus + " ");
			
			State rState = ((Cell)Cell.Cells[MyPos.ToIndex()]).select();
			if (rState == State.Lost)
				dump();
			return rState; 
		}

		/// <summary>
		/// Relays the status messages from the player to be displayed
		/// </summary>
		/// <param name="s1">Message to display</param>
		/// <returns>true</returns>
		public bool setStatus( String s1 )
		{
			System.Diagnostics.Trace.WriteLine(s1);
			return true;
		}

		/// <summary>
		/// Get the number of uncovered cells
		/// </summary>
		/// <returns>The number of uncovered cells</returns>
		public int getNbrOfUncoveredCells() 
		{
			return Dem.iCellsUnv;
		}
		
		/// <summary>
		/// Player is requesting the number of rows
		/// </summary>
		/// <returns>The number of rows</returns>
		public int getNumberOfRows()
		{
			return Dem.iTotRows;
		}

		/// <summary>
		/// Player is setting the number of rows
		/// </summary>
		/// <param name="r">number of rows</param>
		/// <returns>false if operation is not completed</returns>
		public bool setNumberOfRows(int r)
		{
			bool bRet = false;
			//IF: [We are not playing currently]
			if (Dem.State != State.Playing)
			{
				bRet = true;
				Dem.iTotRows = r;
			}
			return bRet;
		}

		/// <summary>
		/// Player is requesting the number of columns
		/// </summary>
		/// <returns>The number of columns</returns>
		public int getNumberOfColumns()
		{
			return Dem.iTotCols;
		}

		/// <summary>
		/// Player is setting the number of columns
		/// </summary>
		/// <param name="c">number of columns</param>
		/// <returns>false if operation is not completed</returns>
		public bool setNumberOfColumns(int c)
		{
			bool bRet = false;
			//IF: [We are not playing currently]
			if (Dem.State != State.Playing)
			{
				bRet = true;
				Dem.iTotCols = c;
			}
			return bRet;
		}

		/// <summary>
		/// Player is requesting the number of bombs
		/// </summary>
		/// <returns>The number of bombs</returns>
		public int getNumberOfBombs()
		{
			return Dem.iTotBoms;
		}

		/// <summary>
		/// Player is setting the number of bombs
		/// </summary>
		/// <param name="c">number of bombs</param>
		/// <returns>false if operation is not completed</returns>
		public bool setNumberOfBombs(int c)
		{
			//If [there are less then one bomb]
			if (c<1)
			{
				throw (new ApplicationException("Logic Error: Number of bombs were less then one."));
			}

			bool bRet = false;
			//IF: [We are not playing currently]
			if (Dem.State != State.Playing)
			{
				//IF: [We do not excede the number of cells]
				if (Dem.iTotCols*Dem.iTotRows>=c)
				{
					bRet = true;
					Dem.iTotBoms = c;
				}
				else
				{
					throw (new ApplicationException("Logic Error: Number of bombs exceed the number of cells."));
				}
			}
			return bRet;
		}

		/// <summary>
		/// Player's requesting for the current state of the board, See cell.getDisplay() for more information.
		/// </summary>
		/// <returns>The array of ASCII values used to represent the cells current state</returns>
		public char[] getDisplay()
		{  
			System.Diagnostics.Trace.WriteLine("Reading the new display state of the cells.");
			char[] Display = new Char[Dem.iTotCols*Dem.iTotRows];
			int i = 0;
			foreach(Cell cell in Cell.Cells)
			{
				Display[i++] = cell.getDisplay();
			}	
			return Display;
		}

		/// <summary>
		/// Internal requesting the state of the board, See cell.getDisplay() for more information. 
		/// </summary>
		/// <returns>The array of ASCII values used to represent the cells current state</returns>
		internal char[] getBoard()
		{  
			System.Diagnostics.Trace.WriteLine("Reading the new display state of the cells.");
			char[] Display = new Char[Dem.iTotCols*Dem.iTotRows];
			int i = 0;
			foreach(Cell cell in Cell.Cells)
			{
				Display[i++] = cell.getOfNbrAdjBombs().ToString()[0];
			}	
			return Display;
		}

		/// <summary>
		/// Wrapper the random function, so I can varry it if nessary
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
	/// Cell positioning control
	/// Pos. of the cell in row and column where
	/// the position is translated to a ones based index.
	/// </summary>
	class Pos 
	{
		int Row; // Cells Row or relative Y axis (1-n)
		int Col; // Cells Cols or relative X axis (1-n)
        
		/// <summary>
		/// Create the position given the abs. Row and Col
		/// </summary>
		/// <param name="C">Column</param>
		/// <param name="R">Row</param>
		public Pos(int C, int R) 
		{
			Row = R;
			Col = C;
			if(R > Dem.iTotRows || C > Dem.iTotCols)
				throw (new ApplicationException("Logic Error: Row or Column out of bounds."));
		}
        
		/// <summary>
		/// Create the position given the zero base index of cells.
		/// </summary>
		/// <param name="idx">index of this position</param>
		public Pos(int idx)
		{
			Row = idx/(Dem.iTotCols)+1; // Row from Cells index
			Col = idx%(Dem.iTotCols)+1; // Col. From Cells index
		}

		/// <summary>
		/// Returns the zero base index for the cell
		/// </summary>
		/// <returns></returns>
		public int ToIndex()
		{
			return ((Row-1)*Dem.iTotCols)+(Col-1);
		}

		/**
		 *  
		 */
		/// <summary>
		/// Gets the ones based row position
		/// </summary>
		/// <returns>The ones based row</returns>
		public int GetRow()
		{
			return Row;
		}

		/// <summary>
		/// Gets the one basd column position
		/// </summary>
		/// <returns>The ones based column for the cell</returns>
		public int GetCol()
		{
			return Col;
		}
	}

	/// <summary>
	/// A Cell in the current game
	/// </summary>
	class Cell 
	{
		public static ArrayList Cells = new ArrayList(); // Index based array of all the cells for the game

		protected bool bomb = false; // Is the cell a bomb?
		protected bool unCovered = false; // Indicates whether this cell has been uncovered
		internal  Pos cPos; // The position of this cell
		protected int nbrOfAdjBombs = 0; // The number of bombs adjacent to this one
		protected ArrayList adjCells; // All adjacent cells to this one

		/// <summary>
		/// Creates a new cell at the given index
		/// </summary>
		/// <param name="idx"></param>
		public Cell(int idx)
		{
			cPos = new Pos(idx);
			adjCells = new ArrayList();
		}
        
		/// <summary>
		/// Gets the boolean bomb property of this cell  
		/// </summary>
		/// <returns>True if this cell is a bomb</returns>
		public bool isBomb() 
		{
			return bomb;
		}
        
		/// <summary>
		/// Sets the boolean bobm property of this cell
		/// </summary>
		/// <param name="bomb">TRUE or FALSE</param>
		public void setBomb(bool bomb) 
		{
			this.bomb = bomb;
		}
        
		/**
		 */
		/// <summary>
		/// Sets up the array of adjacent cells to this one
		/// Note: Should be called only after we set all the bombs 
		/// </summary>
		public void hookAdjCells() 
		{
			//IF [I am not a bomb]
			if (bomb == false) 
			{
				try 
				{
					//IF [there is a row above this one]
					if (this.cPos.GetRow() > 1) 
					{
						//IF [there is a cell before this one]
						if (this.cPos.GetCol() > 1) 
						{
							adjCells.Add(Cells[new Pos(this.cPos.GetCol()-1,this.cPos.GetRow()-1).ToIndex()]);
						}
						adjCells.Add(Cells[new Pos(this.cPos.GetCol(),this.cPos.GetRow()-1).ToIndex()]);
						//IF [there is a cell after this one]
						if (this.cPos.GetCol() < Dem.iTotCols) 
						{
							adjCells.Add(Cells[new Pos(this.cPos.GetCol()+1,this.cPos.GetRow()-1).ToIndex()]);
						}
					}
					//IF [there is a cell before this one]
					if (this.cPos.GetCol() > 1) 
					{
						adjCells.Add(Cells[new Pos(this.cPos.GetCol()-1,this.cPos.GetRow()).ToIndex()]);
					}
					//IF [there is a cell after this one]
					if (this.cPos.GetCol() < Dem.iTotCols) 
					{
						adjCells.Add(Cells[new Pos(this.cPos.GetCol()+1,this.cPos.GetRow()).ToIndex()]);
					}
					//IF [there is a row below this one]
					if (this.cPos.GetRow() < Dem.iTotRows) 
					{
						//IF [there is a cell before this one]
						if (this.cPos.GetCol() > 1) 
						{
							adjCells.Add(Cells[new Pos(this.cPos.GetCol()-1,this.cPos.GetRow()+1).ToIndex()]);
						}
						adjCells.Add(Cells[new Pos(this.cPos.GetCol(),this.cPos.GetRow()+1).ToIndex()]);
						//IF [there is a cell after this one]
						if (this.cPos.GetCol() < Dem.iTotCols) 
						{
							adjCells.Add(Cells[new Pos(this.cPos.GetCol()+1,this.cPos.GetRow()+1).ToIndex()]);
						}
					}
					// Calculate the number of adjacent bombs
					for (int x=0; x<adjCells.Count; x++) 
					{
						Cell CTemp = (Cell)adjCells[x];
						if ( CTemp.isBomb() == true) 
						{
							nbrOfAdjBombs++;
						}
					}
				} 
				catch(Exception e) 
				{
					MessageBox.Show ("Exception error: " + e.Message, "My Application", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
			}
		}
        
		/// <summary>
		/// Gets property nbrOfAdjBombs
		/// return Value of property nbrOfAdjBombs
		/// </summary>
		/// <returns></returns>
		public int getOfNbrAdjBombs() 
		{
			return nbrOfAdjBombs;
		}

		/// <summary>
		/// Determans of the cell is playable
		/// </summary>
		/// <returns>True if cell is not a bomb and not uncovered</returns>
		public bool isPlayable()
		{
			//IF: [The cell is still covered and is not a bomb]
			return isBomb()==false && unCovered==false;
		}
        
		/// <summary>
		/// Selects this cell
		/// </summary>
		/// <returns>State of the operation</returns>
		public MindSweep.State select() 
		{
			//IF: [This cell has already been uncovered] then [Don't waste my time}
			if (unCovered == true)
			{
				System.Diagnostics.Trace.WriteLine("Cell is all ready uncovered");
				return Dem.State;
			}

			//IF: [State is not Playing] Then [Throw an error]
			if (Dem.State != MindSweep.State.Playing) 
			{
				String sout = "Error Game State is ";
				switch(Dem.State) 
				{
					case State.Limbo:
						sout += "Limbo";
						break;
					case State.Lost:
						sout += "Lost";
						break;
					case State.Playing:
						sout += "Playing";
						break;
					case State.Won:
						sout += "Won";
						break;
				}
				System.Diagnostics.Trace.WriteLine(TrcDf.SubStatus + sout );
				return Dem.State;
			}

			unCovered = true; // This cell is now uncovered
			Dem.iCellsUnv++; // The number of cells uncovered total

			//IF [I am a bomb] 
			if (isBomb() == true) 
			{
				System.Diagnostics.Trace.WriteLine(TrcDf.SubStatus + "***** This cell is a bomb *****" );
				Dem.State = MindSweep.State.Lost; // U Loose
				System.Diagnostics.Trace.WriteLine( TrcDf.Losses + ++Dem.iTotLosses );
				System.Diagnostics.Trace.WriteLine(TrcDf.Status + "Lost");
				System.Collections.IEnumerator SCE = Cell.Cells.GetEnumerator();
			} 
			else 
			{
				//IF: [This cell is neutral] Then [Uncover all adjacent cells]
				if (nbrOfAdjBombs == 0) 
				{
					ArrayList adjCellsToCheckNow = new ArrayList();
					adjCellsToCheckNow.AddRange(adjCells);
					ArrayList adjCellsToCheckNext = new ArrayList();
					do
					{
						adjCellsToCheckNext.Clear();
						// Auto uncover adjacent cells to the neutral one
						foreach (Cell c in adjCellsToCheckNow) 
						{
							// IF: [The cell is not uncovered now] Then [uncover it now]
							if (!c.unCovered)
							{
								Dem.iAutoUnv++; // The number of cells that were uncovered automatically
								Dem.iCellsUnv++; // The number of cells uncovered total
								c.unCovered = true; 
								//IF: [This cell is also neutral] then [Continue the chain reaction]
								if (c.nbrOfAdjBombs == 0)
									adjCellsToCheckNext.AddRange(c.adjCells);
							}
						}
						adjCellsToCheckNow.Clear();
						adjCellsToCheckNow.AddRange(adjCellsToCheckNext);
					} while(adjCellsToCheckNow.Count > 0);
				}
			}

			// Update the Display
			System.Diagnostics.Trace.WriteLine(TrcDf.SubStatus + "Total number of cells uncovered so far is " +  Dem.iCellsUnv);
			System.Diagnostics.Trace.WriteLine(TrcDf.Remaining + (Dem.iTotCols*Dem.iTotRows-Dem.iTotBoms-Dem.iCellsUnv) );
			System.Diagnostics.Trace.WriteLine(TrcDf.AutoUnv + Dem.iAutoUnv );

			//IF: [U have not lost] Then [have you have possibly won?]
			if (Dem.State != MindSweep.State.Lost)
			{
				bool bPlayable = false; 
				foreach(Cell cell in Cell.Cells)
				{
					// IF: [There are playable cells left] Then [You have not won yet]
					if ( cell.isPlayable() )
					{
						bPlayable = true;
						break;
					}
				}
				//IF: [There were no playable cells left] then [You have Won!]
				if (bPlayable == false)
				{
					Dem.State = MindSweep.State.Won;
					System.Diagnostics.Trace.WriteLine(TrcDf.SubStatus + "***** You have won ******" );
					System.Diagnostics.Trace.WriteLine(TrcDf.Status + "won");
					System.Diagnostics.Trace.WriteLine( TrcDf.Wins + ++Dem.iTotWins );
				}
			}

			return Dem.State;
		}

		/// <summary>
		/// Gets the perspective state of this cell
		/// Returns as 'U'ncovered, 'C'overed, 'B'omb or 
		/// N the number of adjacent bombs in ASCII '1' - '8'
		/// </summary>
		/// <returns>ASCII values of 'U','C','B' or '1' to '8'</returns>
		public char getDisplay() 
		{
			char chr = 'U';
			if (Dem.State == MindSweep.State.Playing)
			{
				//IF [Not selected]
				if (unCovered == false) 
				{
					chr = 'C';
				} 
				else 
				{
					//IF [This is a bomb] 
					if (isBomb() == true) 
					{
						throw (new ApplicationException("Logic Error: uncovered cell is a bomb."));
					}
					else
					{
						chr = nbrOfAdjBombs.ToString()[0];
					}
				}
			}
			else
			{
				// Debugging 
				//IF [This is a bomb] 
				if (isBomb() == true) 
				{
					chr = 'B'; // Show All the bombs now
				}
				else
				//IF [Not selected]
				if (unCovered == false) 
				{
					chr = 'C';
				} 
				else 
				{
					chr = nbrOfAdjBombs.ToString()[0];
				}
			}
			return chr;
		}
	}
}
