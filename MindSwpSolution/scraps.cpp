					DateTime dt2 = System.DateTime.Now;
					FileStream fs;
					if (!File.Exists("C:\\minesweep.txt"))
						fs = File.Create("C:\\minesweep.txt");
					else
						fs = File.OpenWrite("C:\\minesweep.txt");
					fs.Seek(0,SeekOrigin.End);
					StreamWriter sw = new StreamWriter( fs );
					sw.Write("\r\n\r\n" + System.DateTime.Now.ToString() + "\r\n");
					ca = GameObj.getDisplay(); 
					int nbrOfUncCells = GameObj.getNbrOfUncoveredCells();
					System.Collections.IEnumerator SCE = ShadowCell.ShadowCells.GetEnumerator();
					nbrUncovered = 0;
					// Update the  shadow cells with the most current display states from the game.
					foreach( char c in ca ) 
					{
						try 
						{

							//IF: [The number of display elements exceed the shadow cells]
							if( SCE.MoveNext() == false )
								throw (new ApplicationException("Logic Error: Game display cells exceed that of the shadow cells."));
							//IF: [The Cell is uncovered]
							if (Char.IsDigit(c) == true)
								nbrUncovered++; // Count the number of uncovered cells.
							// Update the shadow cells accordingly
							((ShadowCell)(SCE.Current)).setDisplay(c);
						} 
						catch( ApplicationException e ) // If there was an unexpected result
						{
							throw (new ApplicationException("Exception Error: Recording Lose: " + e.Message));
						}
					}
					SCE = ShadowCell.ShadowCells.GetEnumerator();
					for(int e=0; e<Dem.iTotRows;e++)
					{
						sw.Write(e.ToString("D7") + " ");
						for(int w=0; w<Dem.iTotCols; w++)
						{
							if( SCE.MoveNext() == false )
								throw (new ApplicationException("Logic Error: Game display cells exceed that of the shadow cells."));
							if (((ShadowCell)(SCE.Current)).getState() == ShadowCell.CurState.Bomb)
								sw.Write("X");
							else
								sw.Write(((ShadowCell)(SCE.Current)).getDisplay());
						}
						sw.Write("\r\n");
					}
					sw.Write("\r\n");
					sw.Write("Count of Guesses " + nbrOfGuesses + "\r\n");
					sw.Write("Count of Uncovered " + (nbrUncovered-1) + " out of " + 
						(Dem.iTotCols*Dem.iTotRows - Dem.iTotBombs) + "\r\n");
					sw.Write("Count of Bombs Descovered " + Dem.ArrShadowBombs.Count + 
						" out of " + Dem.iTotBombs + "\r\n");
					foreach(String s in LastGuesses) 
					{
						sw.Write(s);
					}
					foreach(String s in MyGuesses) 
					{
						sw.Write(s);
					}
//					foreach(ShadowCell sc1 in Dem.ArrShadowBombs) 
//					{
//						sw.Write("\r\n" + "Bomb At Row" + sc1.getPos().GetRow() + " Col" + sc1.getPos().GetCol() );
//					}
					sw.Close();
