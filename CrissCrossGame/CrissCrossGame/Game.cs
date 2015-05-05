using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using WMPLib;
using CrissCrossGame.bin;

namespace CrissCrossGame
{
    public partial class Game : Form
    {
        private String CurrentPath;
        public string oponentIP = "", mynickname = "";
        int chergaPlayer = 0, chergaComp = 0, ScorePlayer = 0, ScoreComp = 0;
        bool move;
        public Form conset;
        int[] field = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        WMPLib.WindowsMediaPlayer wmplayer = new WindowsMediaPlayer();
        public Game()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCriss_Click(object sender, EventArgs e)
        {
            chergaPlayer = 1;
            chergaComp = 2;
            move = true;
            groupBox1.Visible = false;
            this.Width = 180;

        }

        private void buttonCross_Click(object sender, EventArgs e)
        {
            chergaPlayer = 2;
            chergaComp = 1; 
            move = false;
            groupBox1.Visible = false;
            this.Width = 180;
            ComputerMove();
        }


        private void buttonField1_Click(object sender, EventArgs e)
        {
            if (move == true)
            {
                if (field[1] == 0)
                {
                    if (chergaPlayer == 1)
                    {
                        CrissInField1();
                        ComputerMove();
                    }
                    else
                    {
                        CrossInField1();
                        ComputerMove();
                    }
                }
            }
        }

        private void buttonField2_Click(object sender, EventArgs e)
        {
            if (move == true)
            {
                if (field[2] == 0)
                {
                    if (chergaPlayer == 1)
                    {
                        CrissInField2();
                        ComputerMove();
                    }
                    else
                    {
                        CrossInField2();
                        ComputerMove();
                    }
                }
            }
        }

        private void buttonField3_Click(object sender, EventArgs e)
        {
            if (move == true)
            {
                if (field[3] == 0)
                {
                    if (chergaPlayer == 1)
                    {
                        CrissInField3();
                        ComputerMove();
                    }
                    else
                    {
                        CrossInField3();
                        ComputerMove();
                    }
                }
            }
        }

        private void buttonField4_Click(object sender, EventArgs e)
        {
            if (move == true)
            {
                if (field[4] == 0)
                {
                    if (chergaPlayer == 1)
                    {
                        CrissInField4();
                        ComputerMove();
                    }
                    else
                    {
                        CrossInField4();
                        ComputerMove();
                    }
                }
            }
        }

        private void buttonField5_Click(object sender, EventArgs e)
        {
            if (move == true)
            {
                if (field[5] == 0)
                {
                    if (chergaPlayer == 1)
                    {
                        CrissInField5();
                        ComputerMove();
                    }
                    else
                    {
                        CrossInField5();
                        ComputerMove();
                    }
                }
            }
        }

        private void buttonField6_Click(object sender, EventArgs e)
        {
            if (move == true)
            {
                if (field[6] == 0)
                {
                    if (chergaPlayer == 1)
                    {
                        CrissInField6();
                        ComputerMove();
                    }
                    else
                    {
                        CrossInField6();
                        ComputerMove();
                    }
                }
            }
        }

        private void buttonField7_Click(object sender, EventArgs e)
        {
            if (move == true)
            {
                if (field[7] == 0)
                {
                    if (chergaPlayer == 1)
                    {
                        CrissInField7();
                        ComputerMove();
                    }
                    else
                    {
                        CrossInField7();
                        ComputerMove();
                    }
                }
            }
            
        }

        private void buttonField8_Click(object sender, EventArgs e)
        {
            if (move == true)
            {
                if (field[8] == 0)
                {
                    if (chergaPlayer == 1)
                    {
                        CrissInField8();
                        ComputerMove();
                    }
                    else
                    {
                        CrossInField8();
                        ComputerMove();
                    }
                }
            }
        }

        private void buttonField9_Click(object sender, EventArgs e)
        {
            if (move == true)
            {
                if (field[9] == 0)
                {
                    if (chergaPlayer == 1)
                    {
                        CrissInField9();
                        ComputerMove();
                    }
                    else
                    {
                        CrossInField9();
                        ComputerMove();
                    }
                }
            }
        }
     
        private void ComputerMove()
        {
                //Проверяем возможность компъютера выиграть
                //Проверяем первую строку по горизонтали
                if (field[1] == chergaComp && field[2] == chergaComp)
                {
                    if (field[3] == 0)
                    {
                        if (chergaComp == 1) CrissInField3();
                        if (chergaComp == 2) CrossInField3();
                        return;
                    }
                }
                if (field[2] == chergaComp && field[3] == chergaComp)
                {
                    if (field[1] == 0)
                    {
                        if (chergaComp == 1) CrissInField1();
                        if (chergaComp == 2) CrossInField1();
                        return;
                    }
                }
                if (field[1] == chergaComp && field[3] == chergaComp)
                {
                    if (field[2] == 0)
                    {
                        if (chergaComp == 1) CrissInField2();
                        if (chergaComp == 2) CrossInField2();
                        return;
                    }
                }
                //Проверяем вторую строку по горизонтали
                if (field[4] == chergaComp && field[5] == chergaComp)
                {
                    if (field[6] == 0)
                    {
                        if (chergaComp == 1) CrissInField6();
                        if (chergaComp == 2) CrossInField6();
                        return;
                    }
                }
                if (field[5] == chergaComp && field[6] == chergaComp)
                {
                    if (field[4] == 0)
                    {
                        if (chergaComp == 1) CrissInField4();
                        if (chergaComp == 2) CrossInField4();
                        return;
                    }
                }
                if (field[4] == chergaComp && field[6] == chergaComp)
                {
                    if (field[5] == 0)
                    {
                        if (chergaComp == 1) CrissInField5();
                        if (chergaComp == 2) CrossInField5();
                        return;
                    }
                }
                //Проверяем третью строку по горизонтали        
                if (field[7] == chergaComp && field[8] == chergaComp)
                {
                    if (field[9] == 0)
                    {
                        if (chergaComp == 1) CrissInField9();
                        if (chergaComp == 2) CrossInField9();
                        return;
                    }
                }
                if (field[8] == chergaComp && field[9] == chergaComp)
                {
                    if (field[7] == 0)
                    {
                        if (chergaComp == 1) CrissInField7();
                        if (chergaComp == 2) CrossInField7();
                        return;
                    }
                }
                if (field[7] == chergaComp && field[9] == chergaComp)
                {
                    if (field[8] == 0)
                    {
                        if (chergaComp == 1) CrissInField8();
                        if (chergaComp == 2) CrossInField8();
                        return;
                    }
                }
                //Проверяем первую строку по вертикали
                if (field[1] == chergaComp && field[4] == chergaComp)
                {
                    if (field[7] == 0)
                    {
                        if (chergaComp == 1) CrissInField7();
                        if (chergaComp == 2) CrossInField7();
                        return;
                    }
                }
                if (field[4] == chergaComp && field[7] == chergaComp)
                {
                    if (field[1] == 0)
                    {
                        if (chergaComp == 1) CrissInField1();
                        if (chergaComp == 2) CrossInField1();
                        return;
                    }
                }
                if (field[1] == chergaComp && field[7] == chergaComp)
                {
                    if (field[4] == 0)
                    {
                        if (chergaComp == 1) CrissInField4();
                        if (chergaComp == 2) CrossInField4();
                        return;
                    }
                }
                //Проверяем вторую строку по вертикали
                if (field[2] == chergaComp && field[5] == chergaComp)
                {
                    if (field[8] == 0)
                    {
                        if (chergaComp == 1) CrissInField8();
                        if (chergaComp == 2) CrossInField8();
                        return;
                    }
                }
                if (field[5] == chergaComp && field[8] == chergaComp)
                {
                    if (field[2] == 0)
                    {
                        if (chergaComp == 1) CrissInField2();
                        if (chergaComp == 2) CrossInField2();
                        return;
                    }
                }
                if (field[2] == chergaComp && field[8] == chergaComp)
                {
                    if (field[5] == 0)
                    {
                        if (chergaComp == 1) CrissInField5();
                        if (chergaComp == 2) CrossInField5();
                        return;
                    }
                }
                //Проверяем третью строку по вертикали
                if (field[3] == chergaComp && field[6] == chergaComp)
                {
                    if (field[9] == 0)
                    {
                        if (chergaComp == 1) CrissInField9();
                        if (chergaComp == 2) CrossInField9();
                        return;
                    }
                }
                if (field[6] == chergaComp && field[9] == chergaComp)
                {
                    if (field[3] == 0)
                    {
                        if (chergaComp == 1) CrissInField3();
                        if (chergaComp == 2) CrossInField3();
                        return;
                    }
                }
                if (field[3] == chergaComp && field[9] == chergaComp)
                {
                    if (field[6] == 0)
                    {
                        if (chergaComp == 1) CrissInField6();
                        if (chergaComp == 2) CrossInField6();
                        return;
                    }
                }
                //Проверяем диагонали
                if (field[1] == chergaComp && field[5] == chergaComp)
                {
                    if (field[9] == 0)
                    {
                        if (chergaComp == 1) CrissInField9();
                        if (chergaComp == 2) CrossInField9();
                        return;
                    };
                }
                if (field[5] == chergaComp && field[9] == chergaComp)
                {
                    if (field[1] == 0)
                    {
                        if (chergaComp == 1) CrissInField1();
                        if (chergaComp == 2) CrossInField1();
                        return;
                    }
                }
                if (field[1] == chergaComp && field[9] == chergaComp)
                {
                    if (field[5] == 0)
                    {
                        if (chergaComp == 1) CrissInField5();
                        if (chergaComp == 2) CrossInField5();
                        return;
                    }
                }
                if (field[3] == chergaComp && field[5] == chergaComp)
                {
                    if (field[7] == 0)
                    {
                        if (chergaComp == 1) CrissInField7();
                        if (chergaComp == 2) CrossInField7();
                        return;
                    }
                }
                if (field[5] == chergaComp && field[7] == chergaComp)
                {
                    if (field[3] == 0)
                    {
                        if (chergaComp == 1) CrissInField3();
                        if (chergaComp == 2) CrossInField3();
                        return;
                    }
                }
                if (field[3] == chergaComp && field[7] == chergaComp)
                {
                    if (field[5] == 0)
                    {
                        if (chergaComp == 1) CrissInField5();
                        if (chergaComp == 2) CrossInField5();
                        return;
                    }
                }
                //Проверяем, не собирается ли противник выиграть
                //Проверяем первую строку по горизонтали
                if (field[1] == chergaPlayer && field[2] == chergaPlayer)
                {
                    if (field[3] == 0)
                    {
                        if (chergaComp == 1) CrissInField3();
                        if (chergaComp == 2) CrossInField3();
                        return;
                    }
                }
                if (field[2] == chergaPlayer && field[3] == chergaPlayer)
                {
                    if (field[1] == 0)
                    {
                        if (chergaComp == 1) CrissInField1();
                        if (chergaComp == 2) CrossInField1();
                        return;
                    }
                }
                if (field[1] == chergaPlayer && field[3] == chergaPlayer)
                {
                    if (field[2] == 0)
                    {
                        if (chergaComp == 1) CrissInField2();
                        if (chergaComp == 2) CrossInField2();
                        return;
                    }
                }
                //Проверяем вторую строку по горизонтали
                if (field[4] == chergaPlayer && field[5] == chergaPlayer)
                {
                    if (field[6] == 0)
                    {
                        if (chergaComp == 1) CrissInField6();
                        if (chergaComp == 2) CrossInField6();
                        return;
                    }
                }
                if (field[5] == chergaPlayer && field[6] == chergaPlayer)
                {
                    if (field[4] == 0)
                    {
                        if (chergaComp == 1) CrissInField4();
                        if (chergaComp == 2) CrossInField4();
                        return;
                    }
                }
                if (field[4] == chergaPlayer && field[6] == chergaPlayer)
                {
                    if (field[5] == 0)
                    {
                        if (chergaComp == 1) CrissInField5();
                        if (chergaComp == 2) CrossInField5();
                        return;
                    }
                }
                //Проверяем третью строку по горизонтали        
                if (field[7] == chergaPlayer && field[8] == chergaPlayer)
                {
                    if (field[9] == 0)
                    {
                        if (chergaComp == 1) CrissInField9();
                        if (chergaComp == 2) CrossInField9();
                        return;
                    }
                }
                if (field[8] == chergaPlayer && field[9] == chergaPlayer)
                {
                    if (field[7] == 0)
                    {
                        if (chergaComp == 1) CrissInField7();
                        if (chergaComp == 2) CrossInField7();
                        return;
                    }
                }
                if (field[7] == chergaPlayer && field[9] == chergaPlayer)
                {
                    if (field[8] == 0)
                    {
                        if (chergaComp == 1) CrissInField8();
                        if (chergaComp == 2) CrossInField8();
                        return;
                    }
                }
                //Проверяем первую строку по вертикали
                if (field[1] == chergaPlayer && field[4] == chergaPlayer)
                {
                    if (field[7] == 0)
                    {
                        if (chergaComp == 1) CrissInField7();
                        if (chergaComp == 2) CrossInField7();
                        return;
                    }
                }
                if (field[4] == chergaPlayer && field[7] == chergaPlayer)
                {
                    if (field[1] == 0)
                    {
                        if (chergaComp == 1) CrissInField1();
                        if (chergaComp == 2) CrossInField1();
                        return;
                    }
                }
                if (field[1] == chergaPlayer && field[7] == chergaPlayer)
                {
                    if (field[4] == 0)
                    {
                        if (chergaComp == 1) CrissInField4();
                        if (chergaComp == 2) CrossInField4();
                        return;
                    }
                }
                //Проверяем вторую строку по вертикали
                if (field[2] == chergaPlayer && field[5] == chergaPlayer)
                {
                    if (field[8] == 0)
                    {
                        if (chergaComp == 1) CrissInField8();
                        if (chergaComp == 2) CrossInField8();
                        return;
                    }
                }
                if (field[5] == chergaPlayer && field[8] == chergaPlayer)
                {
                    if (field[2] == 0)
                    {
                        if (chergaComp == 1) CrissInField2();
                        if (chergaComp == 2) CrossInField2();
                        return;
                    }
                }
                if (field[2] == chergaPlayer && field[8] == chergaPlayer)
                {
                    if (field[5] == 0)
                    {
                        if (chergaComp == 1) CrissInField5();
                        if (chergaComp == 2) CrossInField5();
                        return;
                    }
                }
                //Проверяем третью строку по вертикали
                if (field[3] == chergaPlayer && field[6] == chergaPlayer)
                {
                    if (field[9] == 0)
                    {
                        if (chergaComp == 1) CrissInField9();
                        if (chergaComp == 2) CrossInField9();
                        return;
                    }
                }
                if (field[6] == chergaPlayer && field[9] == chergaPlayer)
                {
                    if (field[3] == 0)
                    {
                        if (chergaComp == 1) CrissInField3();
                        if (chergaComp == 2) CrossInField3();
                        return;
                    }
                }
                if (field[3] == chergaPlayer && field[9] == chergaPlayer)
                {
                    if (field[6] == 0)
                    {
                        if (chergaComp == 1) CrissInField6();
                        if (chergaComp == 2) CrossInField6();
                        return;
                    }
                }
                //Проверяем диагонали
                if (field[1] == chergaPlayer && field[5] == chergaPlayer)
                {
                    if (field[9] == 0)
                    {
                        if (chergaComp == 1) CrissInField9();
                        if (chergaComp == 2) CrossInField9();
                        return;
                    }
                }
                if (field[5] == chergaPlayer && field[9] == chergaPlayer)
                {
                    if (field[1] == 0)
                    {
                        if (chergaComp == 1) CrissInField1();
                        if (chergaComp == 2) CrossInField1();
                        return;
                    }
                }
                if (field[1] == chergaPlayer && field[9] == chergaPlayer)
                {
                    if (field[5] == 0)
                    {
                        if (chergaComp == 1) CrissInField5();
                        if (chergaComp == 2) CrossInField5();
                        return;
                    }
                }
                if (field[3] == chergaPlayer && field[5] == chergaPlayer)
                {
                    if (field[7] == 0)
                    {
                        if (chergaComp == 1) CrissInField7();
                        if (chergaComp == 2) CrossInField7();
                        return;
                    }
                }
                if (field[5] == chergaPlayer && field[7] == chergaPlayer)
                {
                    if (field[3] == 0)
                    {
                        if (chergaComp == 1) CrissInField3();
                        if (chergaComp == 2) CrossInField3();
                        return;
                    }
                }
                if (field[3] == chergaPlayer && field[7] == chergaPlayer)
                {
                    if (field[5] == 0)
                    {
                        if (chergaComp == 1) CrissInField5();
                        if (chergaComp == 2) CrossInField5();
                        return;
                    }
                }
                //После проверки на возможность проиграша пытаемся выиграть
                //Если есть возможность, обязательно ставим в центр
                if (field[5] == 0)
                {
                    if (chergaComp == 1) CrissInField5();
                    if (chergaComp == 2) CrossInField5();
                    return;
                }
                //Следующий ход в один из углов
                if (field[1] == 0 && field[9] != chergaPlayer)
                {
                    if (chergaComp == 1) CrissInField9();
                    if (chergaComp == 2) CrossInField9();
                    return;
                }
                if (field[3] == 0 && field[7] != chergaPlayer)
                {
                    if (chergaComp == 1) CrissInField3();
                    if (chergaComp == 2) CrossInField3();
                    return;
                }
                if (field[7] == 0 && field[3] != chergaPlayer)
                {
                    if (chergaComp == 1) CrissInField7();
                    if (chergaComp == 2) CrossInField7();
                    return;
                }
                if (field[9] == 0 && field[1] != chergaPlayer)
                {
                    if (chergaComp == 1) CrissInField9();
                    if (chergaComp == 2) CrossInField9();
                    return;
                }
                //Следующий ход в одну из средних полос
                if (field[2] == 0 && field[8] != chergaPlayer)
                {
                    if (chergaComp == 1) CrissInField2();
                    if (chergaComp == 2) CrossInField2();
                    return;
                }
                if (field[3] == 0 && field[7] != chergaPlayer)
                {
                    if (chergaComp == 1) CrissInField3();
                    if (chergaComp == 2) CrossInField3();
                    return;
                }
                if (field[7] == 0 && field[3] != chergaPlayer)
                {
                    if (chergaComp == 1) CrissInField7();
                    if (chergaComp == 2) CrossInField7();
                    return;
                }
                if (field[9] == 0 && field[3] != chergaPlayer)
                {
                    if (chergaComp == 1) CrissInField9();
                    if (chergaComp == 2) CrossInField9();
                    return;
                }
                //Ищем первую свободную ячейку
                if (field[1] == 0)
                {
                    if (chergaComp == 1) CrissInField1();
                    if (chergaComp == 2) CrossInField1();
                    return;     
                }
                if (field[2] == 0)
                {
                    if (chergaComp == 1) CrissInField2();
                    if (chergaComp == 2) CrossInField2();
                    return;     
                }
                if (field[3] == 0)
                {
                    if (chergaComp == 1) CrissInField3();
                    if (chergaComp == 2) CrossInField3();
                    return;     
                }
                if (field[4] == 0)
                {
                    if (chergaComp == 1) CrissInField4();
                    if (chergaComp == 2) CrossInField4();
                    return;     
                }
                if (field[5] == 0)
                {
                    if (chergaComp == 1) CrissInField5();
                    if (chergaComp == 2) CrossInField5();
                    return;     
                }
                if (field[6] == 0)
                {
                    if (chergaComp == 1) CrissInField6();
                    if (chergaComp == 2) CrossInField6();
                    return;     
                }
                if (field[7] == 0)
                {
                    if (chergaComp == 1) CrissInField7();
                    if (chergaComp == 2) CrossInField7();
                    return;     
                }
                if (field[8] == 0)
                {
                    if (chergaComp == 1) CrissInField8();
                    if (chergaComp == 2) CrossInField8();
                    return;                    
                }
                if (field[9] == 0)
                {
                    if (chergaComp == 1) CrissInField9();
                    if (chergaComp == 2) CrossInField9();
                    return;
                }
}       

        private void ResetGame()
        {
            buttonField1.BackgroundImage = null;
            buttonField2.BackgroundImage = null;
            buttonField3.BackgroundImage = null;
            buttonField4.BackgroundImage = null;
            buttonField5.BackgroundImage = null;
            buttonField6.BackgroundImage = null;
            buttonField7.BackgroundImage = null;
            buttonField8.BackgroundImage = null;
            buttonField9.BackgroundImage = null;
            for (int i = 0; i < 10; i++)
            {
                field[i] = 0;
            }
            chergaPlayer = 3;
            chergaComp = 3;
            move = false;
            groupBox1.Visible = true;
            this.Width = 300;
        }

        private void GameIsOver()
        {
                //Проверка победы пользователя
                if (field[1] == chergaPlayer && field[2] == chergaPlayer && field[3] == chergaPlayer)
                {
                    MessageBox.Show("Поздравляем! Выиграл пользователь!");
                    ScorePlayer++;
                    PlayerScore.Text = ScorePlayer.ToString();
                    ResetGame();
                }
                if (field[4] == chergaPlayer && field[5] == chergaPlayer && field[6] == chergaPlayer)
                {
                    MessageBox.Show("Поздравляем! Выиграл пользователь!");
                    ScorePlayer++;
                    PlayerScore.Text = ScorePlayer.ToString();
                    ResetGame();
                }
                if (field[7] == chergaPlayer && field[8] == chergaPlayer && field[9] == chergaPlayer)
                {
                    MessageBox.Show("Поздравляем! Выиграл пользователь!");
                    ScorePlayer++;
                    PlayerScore.Text = ScorePlayer.ToString();
                    ResetGame();
                }
                if (field[1] == chergaPlayer && field[4] == chergaPlayer && field[7] == chergaPlayer)
                {
                    MessageBox.Show("Поздравляем! Выиграл пользователь!");
                    ScorePlayer++;
                    PlayerScore.Text = ScorePlayer.ToString();
                    ResetGame();
                }
                if (field[2] == chergaPlayer && field[5] == chergaPlayer && field[8] == chergaPlayer)
                {
                    MessageBox.Show("Поздравляем! Выиграл пользователь!");
                    ScorePlayer++;
                    PlayerScore.Text = ScorePlayer.ToString();
                    ResetGame();
                }
                if (field[3] == chergaPlayer && field[6] == chergaPlayer && field[9] == chergaPlayer)
                {
                    MessageBox.Show("Поздравляем! Выиграл пользователь!");
                    ScorePlayer++;
                    PlayerScore.Text = ScorePlayer.ToString();
                    ResetGame();
                }
                if (field[1] == chergaPlayer && field[5] == chergaPlayer && field[9] == chergaPlayer)
                {
                    MessageBox.Show("Поздравляем! Выиграл пользователь!");
                    ScorePlayer++;
                    PlayerScore.Text = ScorePlayer.ToString();
                    ResetGame();
                }
                if (field[3] == chergaPlayer && field[5] == chergaPlayer && field[7] == chergaPlayer)
                {
                    MessageBox.Show("Поздравляем! Выиграл пользователь!");
                    ScorePlayer++;
                    PlayerScore.Text = ScorePlayer.ToString();
                    ResetGame();
                }

                //Проверка победы компъютера

                if (field[1] == chergaComp && field[2] == chergaComp && field[3] == chergaComp)
                {
                    MessageBox.Show("Сожалеем! Вы проиграли!");
                    ScoreComp++;
                    CompScore.Text = ScoreComp.ToString();
                    ResetGame();
                }
                if (field[4] == chergaComp && field[5] == chergaComp && field[6] == chergaComp)
                {
                    MessageBox.Show("Сожалеем! Вы проиграли!");
                    ScoreComp++;
                    CompScore.Text = ScoreComp.ToString();
                    ResetGame();
                }
                if (field[7] == chergaComp && field[8] == chergaComp && field[9] == chergaComp)
                {
                    MessageBox.Show("Сожалеем! Вы проиграли!");
                    ScoreComp++;
                    CompScore.Text = ScoreComp.ToString();
                    ResetGame();
                }
                if (field[1] == chergaComp && field[4] == chergaComp && field[7] == chergaComp)
                {
                    MessageBox.Show("Сожалеем! Вы проиграли!");
                    ScoreComp++;
                    CompScore.Text = ScoreComp.ToString();
                    ResetGame();
                }
                if (field[2] == chergaComp && field[5] == chergaComp && field[8] == chergaComp)
                {
                    MessageBox.Show("Сожалеем! Вы проиграли!");
                    ScoreComp++;
                    CompScore.Text = ScoreComp.ToString();
                    ResetGame();
                }
                if (field[3] == chergaComp && field[6] == chergaComp && field[9] == chergaComp)
                {
                    MessageBox.Show("Сожалеем! Вы проиграли!");
                    ScoreComp++;
                    CompScore.Text = ScoreComp.ToString();
                    ResetGame();
                }
                if (field[1] == chergaComp && field[5] == chergaComp && field[9] == chergaComp)
                {
                    MessageBox.Show("Сожалеем! Вы проиграли!");
                    ScoreComp++;
                    CompScore.Text = ScoreComp.ToString();
                    ResetGame();
                }
                if (field[3] == chergaComp && field[5] == chergaComp && field[7] == chergaComp)
                {
                    MessageBox.Show("Сожалеем! Вы проиграли!");
                    ScoreComp++;
                    CompScore.Text = ScoreComp.ToString();
                    ResetGame();
                }
                
            
            if (field[1] != 0 && field[2] != 0 && field[3] != 0 && field[4] != 0 && field[5] != 0 &&
                    field[6] != 0 && field[7] != 0 && field[8] != 0 && field[9] != 0)
            {
                MessageBox.Show("Ничья!");
                ResetGame();
            }
        }

        private void CrissInField1()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Criss));
            buttonField1.BackgroundImage = image;
            buttonField1.BackgroundImageLayout = ImageLayout.Stretch;
            field[1] = 1;
            move = !move;
            GameIsOver();
        }
        
        private void CrossInField1()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Cross));
            buttonField1.BackgroundImage = image;
            buttonField1.BackgroundImageLayout = ImageLayout.Stretch;
            field[1] = 2;
            move = !move;
            GameIsOver();
        }
       
        private void CrissInField2()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Criss));
            buttonField2.BackgroundImage = image;
            buttonField2.BackgroundImageLayout = ImageLayout.Stretch;
            field[2] = 1;
            move = !move;
            GameIsOver();
        }
        
        private void CrossInField2()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Cross));
            buttonField2.BackgroundImage = image;
            buttonField2.BackgroundImageLayout = ImageLayout.Stretch;
            field[2] = 2;
            move = !move;
            GameIsOver();
        }
        
        private void CrissInField3()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Criss));
            buttonField3.BackgroundImage = image;
            buttonField3.BackgroundImageLayout = ImageLayout.Stretch;
            field[3] = 1;
            move = !move;
            GameIsOver();
        }
        
        private void CrossInField3()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Cross));
            buttonField3.BackgroundImage = image;
            buttonField3.BackgroundImageLayout = ImageLayout.Stretch;
            field[3] = 2;
            move = !move;
            GameIsOver();
        }
        
        private void CrissInField4()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Criss));
            buttonField4.BackgroundImage = image;
            buttonField4.BackgroundImageLayout = ImageLayout.Stretch;
            field[4] = 1;
            move = !move;
            GameIsOver();
        }
        
        private void CrossInField4()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Cross));
            buttonField4.BackgroundImage = image;
            buttonField4.BackgroundImageLayout = ImageLayout.Stretch;
            field[4] = 2;
            move = !move;
            GameIsOver();
        }
        
        private void CrissInField5()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Criss));
            buttonField5.BackgroundImage = image;
            buttonField5.BackgroundImageLayout = ImageLayout.Stretch;
            field[5] = 1;
            move = !move;
            GameIsOver();
        }
       
        private void CrossInField5()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Cross));
            buttonField5.BackgroundImage = image;
            buttonField5.BackgroundImageLayout = ImageLayout.Stretch;
            field[5] = 2;
            move = !move;
            GameIsOver();
        }
        
        private void CrissInField6()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Criss));
            buttonField6.BackgroundImage = image;
            buttonField6.BackgroundImageLayout = ImageLayout.Stretch;
            field[6] = 1;
            move = !move;
            GameIsOver();
        }
        
        private void CrossInField6()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Cross));
            buttonField6.BackgroundImage = image;
            buttonField6.BackgroundImageLayout = ImageLayout.Stretch;
            field[6] = 2;
            move = !move;
            GameIsOver();
        }
       
        private void CrissInField7()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Criss));
            buttonField7.BackgroundImage = image;
            buttonField7.BackgroundImageLayout = ImageLayout.Stretch;
            field[7] = 1;
            move = !move;
            GameIsOver();
        }
       
        private void CrossInField7()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Cross));
            buttonField7.BackgroundImage = image;
            buttonField7.BackgroundImageLayout = ImageLayout.Stretch;
            field[7] = 2;
            move = !move;
            GameIsOver();
        }
        
        private void CrissInField8()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Criss));
            buttonField8.BackgroundImage = image;
            buttonField8.BackgroundImageLayout = ImageLayout.Stretch;
            field[8] = 1;
            move = !move;
            GameIsOver();
        }
        
        private void CrossInField8()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Cross));
            buttonField8.BackgroundImage = image;
            buttonField8.BackgroundImageLayout = ImageLayout.Stretch;
            field[8] = 2;
            move = !move;
            GameIsOver();
        }
        
        private void CrissInField9()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Criss));
            buttonField9.BackgroundImage = image;
            buttonField9.BackgroundImageLayout = ImageLayout.Stretch;
            field[9] = 1;
            move = !move;
            GameIsOver();
        }
       
        private void CrossInField9()
        {
            Image image = ((System.Drawing.Image)(Properties.Resources.Cross));
            buttonField9.BackgroundImage = image;
            buttonField9.BackgroundImageLayout = ImageLayout.Stretch;
            field[9] = 2;
            move = !move;
            GameIsOver();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void MenuNewGame_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "mp3 files (*.mp3)|*.mp3";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CurrentPath = dlg.FileName;
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (CurrentPath == null)
            {
                MessageBox.Show("Выберите файл!");
                buttonBrowse_Click(null, null);
            }
            else
            {
                wmplayer.URL = CurrentPath;
                wmplayer.controls.play();
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            wmplayer.controls.pause();
        }

        private void ConnectionSettings_Click(object sender, EventArgs e)
        {
            if (setting.)
            conset = new setting();
            conset.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form conset = new setting();
            conset.Dispose();
            Form chat = new Chat();
            chat.Dispose();
            Dispose();
        }

        private void chat_Click(object sender, EventArgs e)
        {
            Point point = new Point(Location.X + 300, Location.Y);
            Chat chat = new Chat();
            chat.Location = point;
            chat.Owner = this;
            chat.ShowDialog();
        }



        }
    }


        

    
    


