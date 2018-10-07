				FileStream fs;
				StreamWriter sw;
				if (!File.Exists("C:\\minesweepergame.txt"))
					fs = File.Create("C:\\minesweepergame.txt");
				else
					fs = File.OpenWrite("C:\\minesweepergame.txt");
				fs.Seek(0,SeekOrigin.End);
				sw = new StreamWriter( fs );
				sw.Write("\r\n\r\n" + System.DateTime.Now.ToString() + "\r\n");
				while(SCE.MoveNext() == true)
				{
					if (((Cell)(SCE.Current)).isBomb() == true)
						sw.Write(("BOMB AT ROW " + ((Cell)(SCE.Current)).cPos.GetRow() +
							" COL " +((Cell)(SCE.Current)).cPos.GetCol() + "\r\n" ));
				}
				sw.Close();
