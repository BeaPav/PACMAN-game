
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

partial class MainForm : Form

{
	Bitmap jedlo,stena,volne;
	StreamReader r = new StreamReader("Pozadie1.txt");

	char [ , ] pozadie = new char[20,20];
	PACMAN P;
	MONSTER[] M = new MONSTER[3];
	Random rnd = new Random();
	int tm=0;

	
	
	void MainFormPaint(object sender, PaintEventArgs e)
	{
		Graphics g = e.Graphics;
		int i,j;
	
		g.FillRectangle(Brushes.Gray,0,0,20*40,20*40);
		
		//kreslim pozadie a pacmana 
		for (i=0; i<20; i++)
		{
			for (j=0;j<20;j++)
			{
				if (pozadie[i,j]=='s')			g.DrawImage(stena,j*40,i*40);
				else if (pozadie[i,j]=='*')		g.DrawImage(jedlo,j*40,i*40);
				else if (pozadie[i,j]==' ')		g.DrawImage(volne,j*40,i*40);
				else if (pozadie[i,j]=='p')		g.DrawImage(volne,j*40,i*40);
			}
		
		}
		
		// kreslim priserky
		for (i=0;i<3;i++)
		{
			M[i].kresli(g);
		}
		
		// kreslim pacmana
		P.kresli(g);
		
	
	
	


	}
	void MainFormLoad(object sender, EventArgs e)
	{
		
		int i,j;
		string s;
		
		
		jedlo =VytvorObrazok("jedlo.png");
		stena =VytvorObrazok("stena.png");
		volne =VytvorObrazok("volne.png");
		
		//nacitavam pozadie, polohu priser a pacmana
		for (i=0; i<20; i++)
		{
			s=r.ReadLine();
			for (j=0;j<20;j++)
			{
				pozadie[i,j]=s[j];
				if ( pozadie[i,j]=='p')
				{
					
					P=new PACMAN(j*40+20,i*40+20);
				}
				else if (pozadie[i,j]=='r')
				{
					M[2]=new MONSTER(j*40+30,i*40+20,2);
					pozadie[i,j]=' ';

				}
				else if (pozadie[i,j]=='g')
				{
					M[0]=new MONSTER(j*40+30,i*40+20,0);
					pozadie[i,j]=' ';
				}
				else if (pozadie[i,j]=='b')
				{
					M[1]=new MONSTER(j*40+30,i*40+20,1);
					pozadie[i,j]=' ';
				}
			}
			
		
		}
		
		
		r.Close();
		
		//nahodne zvolim pohyb priseriek
		for (i=0;i<3;i++)
		{
			M[i].smer=rnd.Next(4);
					if (M[i].smer==0)
					{
						M[i].dx=0;
						M[i].dy=7;
					}
					else if(M[i].smer == 1)
					{
						M[i].dx=0;
						M[i].dy=-7;
					}
					else if (M[i].smer==2)
					{
						M[i].dy=0;
						M[i].dx=7;
					}
					else
					{
						M[i].dy=0;
						M[i].dx=-7;
					}
		}
		
		timer1.Enabled=true;
		
	}


	protected override bool ProcessDialogKey(Keys keyData)
	{
		
		
		
		if (keyData == Keys.Left)
		{
			P.dx=-5;
			P.dy=0;
			P.smer=2;
			
			if (P.faza<2)		P.faza++;
			else				P.faza=0;
			
		}
		else if  (keyData == Keys.Right)
		{
			P.dx=5;
			P.dy=0;
			P.smer=3;
			
			if (P.faza<2)		P.faza++;
			else				P.faza=0;
		}
		else if (keyData == Keys.Down)
		{
			P.dy=5;
			P.dx=0;
			P.smer=0;
			
			if (P.faza<2)		P.faza++;
			else				P.faza=0;
		}
		else if (keyData == Keys.Up)
		{
			P.dy=-5;
			P.dx=0;
			P.smer=1;
			
			if (P.faza<2)		P.faza++;
			else				P.faza=0;
		}
		
		P.Pohni(pozadie);
		
		

		return base.ProcessDialogKey(keyData);
		
		
	}





	
	
	
	

	
	void Timer1Tick(object sender, EventArgs e)
	{
		int i;
		//P.Pohni(pozadie);
		for (i=0;i<3;i++)
		{
			
			M[i].Pohni(pozadie,tm);
		}
		
		
		
		
		tm=tm+1;
		
		Invalidate();
		
		
		if(Vyhralsi()==true)
		{
			timer1.Enabled=false;
			MessageBox.Show("Vyhral si");
			
		}
		
		if (Kolizia()==true)
		{
			timer1.Enabled=false;
			MessageBox.Show("Prehral si");
			
		}
	}
	
	
	
	
	
	
	Bitmap VytvorObrazok(string s)
	{
		Bitmap obr;
		obr=new Bitmap(s);
		obr=new Bitmap(obr,40,40);
		return obr;
	}
	
	bool Kolizia()
	{
		int i;
		bool b=false;
		for (i=0;i<3;i++)
		{
		
			if (M[i].x>P.x-25 && M[i].x<P.x+25 && M[i].y>P.y-25 && M[i].y<P.y+25)
					{
						b=true;
					}
		}
		return b;
	}
	
	bool Vyhralsi()
	{
		int i ,j;
		bool b=true;
		for (j=0;j<20;j++)
		{
			for(i=0;i<20;i++)
			{
				if(pozadie[j,i]=='*')		b=false;
			}
		}
		return b;
	}
	
	
	
	
	
	void Button1Click(object sender, EventArgs e)
	{
		int i,j;
		string s;
		StreamReader r1 = new StreamReader("Pozadie1.txt");
		//nacitavam pozadie, polohu priser a pacmana
		for (i=0; i<20; i++)
		{
			s=r1.ReadLine();
			for (j=0;j<20;j++)
			{
				pozadie[i,j]=s[j];
				if ( pozadie[i,j]=='p')
				{
					
					P=new PACMAN(j*40+20,i*40+20);
				}
				else if (pozadie[i,j]=='r')
				{
					M[2]=new MONSTER(j*40+30,i*40+20,2);
					pozadie[i,j]=' ';

				}
				else if (pozadie[i,j]=='g')
				{
					M[0]=new MONSTER(j*40+30,i*40+20,0);
					pozadie[i,j]=' ';
				}
				else if (pozadie[i,j]=='b')
				{
					M[1]=new MONSTER(j*40+30,i*40+20,1);
					pozadie[i,j]=' ';
				}
			}
		
		}
		
		//nahodne zvolim pohyb priseriek
		for (i=0;i<3;i++)
		{
			M[i].smer=rnd.Next(4);
					if (M[i].smer==0)
					{
						M[i].dx=0;
						M[i].dy=7;
					}
					else if(M[i].smer == 1)
					{
						M[i].dx=0;
						M[i].dy=-7;
					}
					else if (M[i].smer==2)
					{
						M[i].dy=0;
						M[i].dx=7;
					}
					else
					{
						M[i].dy=0;
						M[i].dx=-7;
					}
		}
		timer1.Enabled=true;
		
	}
	
	
	
	void Button2Click(object sender, EventArgs e)
	{
		int i,j;
		string s;
		StreamReader r2 = new StreamReader("Pozadie2.txt");
		//nacitavam pozadie, polohu priser a pacmana
		for (i=0; i<20; i++)
		{
			s=r2.ReadLine();
			for (j=0;j<20;j++)
			{
				pozadie[i,j]=s[j];
				if ( pozadie[i,j]=='p')
				{
					
					P=new PACMAN(j*40+20,i*40+20);
				}
				else if (pozadie[i,j]=='r')
				{
					M[2]=new MONSTER(j*40+30,i*40+20,2);
					pozadie[i,j]=' ';

				}
				else if (pozadie[i,j]=='g')
				{
					M[0]=new MONSTER(j*40+30,i*40+20,0);
					pozadie[i,j]=' ';
				}
				else if (pozadie[i,j]=='b')
				{
					M[1]=new MONSTER(j*40+30,i*40+20,1);
					pozadie[i,j]=' ';
				}
			}
		
		}
		
		//nahodne zvolim pohyb priseriek
		for (i=0;i<3;i++)
		{
			M[i].smer=rnd.Next(4);
					if (M[i].smer==0)
					{
						M[i].dx=0;
						M[i].dy=7;
					}
					else if(M[i].smer == 1)
					{
						M[i].dx=0;
						M[i].dy=-7;
					}
					else if (M[i].smer==2)
					{
						M[i].dy=0;
						M[i].dx=7;
					}
					else
					{
						M[i].dy=0;
						M[i].dx=-7;
					}
		}
		timer1.Enabled=true;
	}
	void Button3Click(object sender, EventArgs e)
	{
		int i,j;
		string s;
		StreamReader r3 = new StreamReader("Pozadie3.txt");
		//nacitavam pozadie, polohu priser a pacmana
		for (i=0; i<20; i++)
		{
			s=r3.ReadLine();
			for (j=0;j<20;j++)
			{
				pozadie[i,j]=s[j];
				if ( pozadie[i,j]=='p')
				{
					
					P=new PACMAN(j*40+20,i*40+20);
				}
				else if (pozadie[i,j]=='r')
				{
					M[2]=new MONSTER(j*40+30,i*40+20,2);
					pozadie[i,j]=' ';

				}
				else if (pozadie[i,j]=='g')
				{
					M[0]=new MONSTER(j*40+30,i*40+20,0);
					pozadie[i,j]=' ';
				}
				else if (pozadie[i,j]=='b')
				{
					M[1]=new MONSTER(j*40+30,i*40+20,1);
					pozadie[i,j]=' ';
				}
			}
		
		}
		
		//nahodne zvolim pohyb priseriek
		for (i=0;i<3;i++)
		{
			M[i].smer=rnd.Next(4);
					if (M[i].smer==0)
					{
						M[i].dx=0;
						M[i].dy=7;
					}
					else if(M[i].smer == 1)
					{
						M[i].dx=0;
						M[i].dy=-7;
					}
					else if (M[i].smer==2)
					{
						M[i].dy=0;
						M[i].dx=7;
					}
					else
					{
						M[i].dy=0;
						M[i].dx=-7;
					}
		}
		timer1.Enabled=true;
	}
	void Button4Click(object sender, EventArgs e)
	{
		int i,j;
		string s;
		StreamReader r4 = new StreamReader("Pozadie4.txt");
		//nacitavam pozadie, polohu priser a pacmana
		for (i=0; i<20; i++)
		{
			s=r4.ReadLine();
			for (j=0;j<20;j++)
			{
				pozadie[i,j]=s[j];
				if ( pozadie[i,j]=='p')
				{
					
					P=new PACMAN(j*40+20,i*40+20);
				}
				else if (pozadie[i,j]=='r')
				{
					M[2]=new MONSTER(j*40+30,i*40+20,2);
					pozadie[i,j]=' ';

				}
				else if (pozadie[i,j]=='g')
				{
					M[0]=new MONSTER(j*40+30,i*40+20,0);
					pozadie[i,j]=' ';
				}
				else if (pozadie[i,j]=='b')
				{
					M[1]=new MONSTER(j*40+30,i*40+20,1);
					pozadie[i,j]=' ';
				}
			}
		
		}
		
		//nahodne zvolim pohyb priseriek
		for (i=0;i<3;i++)
		{
			M[i].smer=rnd.Next(4);
					if (M[i].smer==0)
					{
						M[i].dx=0;
						M[i].dy=7;
					}
					else if(M[i].smer == 1)
					{
						M[i].dx=0;
						M[i].dy=-7;
					}
					else if (M[i].smer==2)
					{
						M[i].dy=0;
						M[i].dx=7;
					}
					else
					{
						M[i].dy=0;
						M[i].dx=-7;
					}
		}
		timer1.Enabled=true;
	}
	
	
	
	void Button5Click(object sender, EventArgs e)
	{
		if (timer1.Enabled==true)		timer1.Enabled=false;
		else							timer1.Enabled=true;
	}

	
	
	
	
	
	
	
	
		
		
	

	
	
}


	class PACMAN
	{
		public int x,y,dx,dy,faza,smer;
		public Bitmap[,] obrazok = new Bitmap[4,4];
		
		public PACMAN(int nx, int ny)
		{
			x=nx;
			y=ny;
			
			int i;
			for (i=0; i<4; i++)
			{
				obrazok[0,i] = new Bitmap (new Bitmap ("Dolu\\"+Convert.ToString(i)+".png"),40,40);
				obrazok[1,i] = new Bitmap (new Bitmap ("Hore\\"+Convert.ToString(i)+".png"),40,40);
				obrazok[2,i] = new Bitmap (new Bitmap ("Vlavo\\"+Convert.ToString(i)+".png"),40,40);
				obrazok[3,i] = new Bitmap (new Bitmap ("Vpravo\\"+Convert.ToString(i)+".png"),40,40);
			}
		}
		
		public void kresli(Graphics g)
		{
			g.DrawImage(obrazok[smer,faza],x-20,y-20);
		}
		
		public void Pohni(char[,] pozadie)
		{
			int r,s,R,S;
			r=y/40;
			s=x/40;
			
			if (r>0 && s>0 && r<19 && s<19)
			{
				R=(y+dy)/40;
				S=(x+dx)/40;
				
				if (pozadie[R,S]==' ')
				{
					x=x+dx;
					y=y+dy;
					pozadie[r,s]=' ';
					pozadie[R,S]='p';
					
					
				}
				else if (pozadie[R,S]=='p')
				{
					x=x+dx;
					y=y+dy;
					
					
				}
				else if (pozadie[R,S]=='*')
				{
					x=x+dx;
					y=y+dy;
					pozadie[r,s]=' ';
					pozadie[R,S]='p';
					
					
				}
			}
			
		}
		
	}
	
	
	class MONSTER
	{
		public int x,y,dx,dy,faza,farba,smer;
		public Bitmap[,] obrazok = new Bitmap[3,4];
		
		public MONSTER(int nx, int ny, int nfarba)
		{
			x=nx;
			y=ny;
			farba=nfarba;
			
			int i;
			for (i=0; i<4; i++)
			{
				obrazok[0,i] = new Bitmap (new Bitmap ("Priserka zelena\\"+Convert.ToString(i)+".png"),40,40);
				obrazok[1,i] = new Bitmap (new Bitmap ("Priserka modra\\"+Convert.ToString(i)+".png"),40,40);
				obrazok[2,i] = new Bitmap (new Bitmap ("Priserka cervena\\"+Convert.ToString(i)+".png"),40,40);
				
			}
		}
		
		public void kresli(Graphics g)
		{
			g.DrawImage(obrazok[farba,faza],x-20,y-20);
		}
		
		public void Pohni(char[,] pozadie, int t)
		{
			int r,s,R,S;
			Random rnd = new Random();
			r=y/40;
			s=x/40;
			
			if (r>0 && s>0 && r<19 && s<19)
			{
				R=(y+dy)/40;
				S=(x+dx)/40;
				
				if (pozadie[R,S]==' ' || pozadie[R,S]=='p' || pozadie[R,S]=='*')
				{
					x=x+dx;
					y=y+dy;
					
					if (faza<2)			faza++;
					else				faza=0;
				}
				if (pozadie[R,S]=='s' || (t+farba)%20==0)
				{
					smer=rnd.Next(4);
					if (smer==0)
					{
						dx=0;
						dy=7;
						
						
					}
					else if(smer == 1)
					{
						dx=0;
						dy=-7;
					}
					else if (smer==2)
					{
						dy=0;
						dx=7;
					}
					else
					{
						dy=0;
						dx=-7;
					}
				}
			}
			
		}
	}

