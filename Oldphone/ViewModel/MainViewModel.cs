using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Oldphone.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string text;
        public string Text { get => text; set
            {
                text = value;
                RaisePropertyChanged();
            } }

        private string word;
        public string Word
        {
            get => word; set
            {
                word = value;
                RaisePropertyChanged();
            }
        }

        private Cursor cursor;
        public List<string> dictionary { get; set; }
        public Cursor Cursor
        {
            get => cursor;
            set
            {
                cursor = value;
                RaisePropertyChanged();
            }
        }
        public MainViewModel()
        {
            dictionary = new List<string>()
            { 
                "salam",
                "necesen",
                "orta",
                "alma"
            };
            task = CreateTask();
            task.Start();
                  
            
        }
        public void Action()
        {
            while (true)
            {
                if (stopWatch.Elapsed.Seconds > 1)
                {
                    stopWatch.Stop();
                    stopWatch.Reset();
                    Cursor = Cursors.Help;
                    Btn_0_count = 0;
                    Btn_1_count = 0;
                    Btn_2_count = 0;
                    Btn_3_count = 0;
                    Btn_4_count = 0;
                    Btn_5_count = 0;
                    Btn_6_count = 0;
                    Btn_7_count = 0;
                    Btn_8_count = 0;
                    if (Text.Contains(" "))
                    {
                        var title = Text.Split(' ').Last();
                        foreach (var word in dictionary)
                        {
                            if (word.StartsWith(title) && title != "")
                            {
                                Word = word;
                            }
                        }
                    }
                    else
                    {
                        var title = Text;
                        foreach (var word in dictionary)
                        {
                            if (word.StartsWith(title) && title != "")
                            {
                                Word = word;
                            }
                        }
                    }
                }
            }
        }
        public Task CreateTask()=>new Task(() => { Action(); });
        public Task task;
        #region Simvols

        public RelayCommand OKCommand
        {
            get => new RelayCommand(() =>
            {
                if (Text.Contains(" "))
                {
                    var title = Text.Split(' ').Last();
                    for (int i = title.Length; i < Word.Length; i++)
                    {
                        Text += Word[i];
                    }
                    Word = "";
                }
                else
                {
                    var title = Text;
                    for (int i = title.Length; i < Word.Length; i++)
                    {
                        Text += Word[i];
                    }
                    Word = "";
                }
            });
        }
        public RelayCommand AddCommand
        {
            get => new RelayCommand(() =>
            {
                if (Text.Contains(" "))
                {
                    var title = Text.Split(' ').Last();
                    dictionary.Add(title);
                }
                else
                {
                    var title = Text;
                    dictionary.Add(title);
                }
            });
        }
      
        public RelayCommand Backspace
        {
            get => new RelayCommand(() =>
            {
                int ind = Text.Length - 1;
                Text = Text.Remove(ind);
            });
        }
        public Stopwatch stopWatch { get; set; } = new Stopwatch();
        private Thread thr { get; set; }
        public RelayCommand OneBtnCmd { get => new RelayCommand(
            () =>
                {
                    Text += "1";
                });
        }
        public RelayCommand StrBtnCmd
        {
            get => new RelayCommand(
            () =>
            {
                Text += "*";
            });
        }
        public RelayCommand SrpBtnCmd
        {
            get => new RelayCommand(
            () =>
            {
                Text += "#";
            });
        }

        private int Btn_0_count { get; set; } = 0;
        public RelayCommand ZeroBtnCmd
        {
            get => new RelayCommand(
            () =>
            {
                stopWatch.Stop();
                if (Btn_0_count == 2)
                {
                    int ind = Text.Length - 1;
                    Text = Text.Remove(ind);
                    Btn_0_count = 0;
                }
                if (Btn_0_count == 0)
                {
                    Text += " ";
                    Btn_0_count++;
                    stopWatch.Start();
                    return;
                }
                else if (Btn_0_count == 1)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_0_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += '0';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }                
                else if (Btn_0_count == 2)
                {
                    Btn_0_count = 0;
                }


            });
        }

        private int Btn_1_count { get; set; } = 0;
        public RelayCommand TwoBtnCmd
        {
            get => new RelayCommand(
            () =>
            {
                stopWatch.Stop();
                if (Btn_1_count == 4)
                {
                    int ind = Text.Length - 1;
                    Text = Text.Remove(ind);
                    Btn_1_count = 0;
                }
                if (Btn_1_count == 0)
                {
                    Text += "a";
                    Btn_1_count++;
                    stopWatch.Start();
                    return;
                }
                else if (Btn_1_count == 1)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_1_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'b';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_1_count == 2)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_1_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'c';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_1_count == 3)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_1_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += '2';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_1_count == 4)
                {
                    Btn_1_count = 0;
                }


            });
        }

        private int Btn_2_count { get; set; } = 0;
        public RelayCommand TreeBtnCmd
        {
            get => new RelayCommand(
            () =>
            {
                stopWatch.Stop();
                if (Btn_2_count == 4)
                {
                    int ind = Text.Length - 1;
                    Text = Text.Remove(ind);
                    Btn_2_count = 0;
                }
                if (Btn_2_count == 0)
                {
                    Text += "d";
                    Btn_2_count++;
                    stopWatch.Start();
                    return;
                }
                else if (Btn_2_count == 1)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_2_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'e';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_2_count == 2)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_2_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'f';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_2_count == 3)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_2_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += '3';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_2_count == 4)
                {
                    Btn_2_count = 0;
                }
            });
        }

        private int Btn_3_count { get; set; } = 0;
        public RelayCommand FourBtnCmd
        {
            get => new RelayCommand(
            () =>
            {
                stopWatch.Stop();
                if (Btn_3_count == 4)
                {
                    int ind = Text.Length - 1;
                    Text = Text.Remove(ind);
                    Btn_3_count = 0;
                }
                if (Btn_3_count == 0)
                {
                    Text += "g";
                    Btn_3_count++;
                    stopWatch.Start();
                    return;
                }
                else if (Btn_3_count == 1)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_3_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'h';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_3_count == 2)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_3_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'i';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_3_count == 3)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_3_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += '4';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_3_count == 4)
                {
                    Btn_3_count = 0;
                }
            });
        }

        private int Btn_4_count { get; set; } = 0;
        public RelayCommand FiveBtnCmd
        {
            get => new RelayCommand(
            () =>
            {
                stopWatch.Stop();
                if (Btn_4_count == 4)
                {
                    int ind = Text.Length - 1;
                    Text = Text.Remove(ind);
                    Btn_4_count = 0;
                }
                if (Btn_4_count == 0)
                {
                    Text += "j";
                    Btn_4_count++;
                    stopWatch.Start();
                    return;
                }
                else if (Btn_4_count == 1)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_4_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'k';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_4_count == 2)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_4_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'l';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_4_count == 3)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_4_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += '5';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_4_count == 4)
                {
                    Btn_4_count = 0;
                }
            });
        }

        private int Btn_5_count { get; set; } = 0;
        public RelayCommand SixBtnCmd
        {
            get => new RelayCommand(
            () =>
            {
                stopWatch.Stop();
                if (Btn_5_count == 4)
                {
                    int ind = Text.Length - 1;
                    Text = Text.Remove(ind);
                    Btn_5_count = 0;
                }
                if (Btn_5_count == 0)
                {
                    Text += "m";
                    Btn_5_count++;
                    stopWatch.Start();
                    return;
                }
                else if (Btn_5_count == 1)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_5_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'n';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_5_count == 2)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_5_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'o';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_5_count == 3)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_5_count ++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += '6';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_5_count == 4)
                {
                    Btn_5_count = 0;
                }
            });
        }

        private int Btn_6_count { get; set; } = 0;
        public RelayCommand SevenBtnCmd
        {
            get => new RelayCommand(
            () =>
            {
                stopWatch.Stop();
                if (Btn_6_count == 5)
                {
                    int ind = Text.Length - 1;
                    Text = Text.Remove(ind);
                    Btn_6_count = 0;
                }
                if (Btn_6_count == 0)
                {
                    Text += "p";
                    Btn_6_count++;
                    stopWatch.Start();
                    return;
                }
                else if (Btn_6_count == 1)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_6_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'q';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_6_count == 2)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_6_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'r';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_6_count == 3)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_6_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 's';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_6_count == 4)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_6_count ++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += '7';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_6_count == 5)
                {
                    Btn_6_count = 0;
                }
            });
        }

        private int Btn_7_count { get; set; } = 0;
        public RelayCommand EightBtnCmd
        {
            get => new RelayCommand(
            () =>
            {
                stopWatch.Stop();
                if (Btn_7_count == 4)
                {
                    int ind = Text.Length - 1;
                    Text = Text.Remove(ind);
                    Btn_7_count = 0;
                }
                if (Btn_7_count == 0)
                {
                    Text += "t";
                    Btn_7_count++;
                    stopWatch.Start();
                    return;
                }
                else if (Btn_7_count == 1)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_7_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'u';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_7_count == 2)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_7_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'v';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_7_count == 3)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_7_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += '8';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_7_count == 4)
                {
                    Btn_7_count = 0;
                }
            });
        }

        private int Btn_8_count { get; set; } = 0;
        public RelayCommand NineBtnCmd
        {
            get => new RelayCommand(
            () =>
            {
                stopWatch.Stop();
                if (Btn_8_count == 5)
                {
                    int ind = Text.Length - 1;
                    Text = Text.Remove(ind);
                    Btn_8_count = 0;
                }
                if (Btn_8_count == 0)
                {
                    Text += "w";
                    Btn_8_count++;
                    stopWatch.Start();
                    return;
                }
                else if (Btn_8_count == 1)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_8_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'x';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_8_count == 2)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_8_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'y';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_8_count == 3)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_8_count++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += 'z';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_8_count == 4)
                {

                    if (stopWatch.Elapsed.Seconds <= 1)
                    {
                        Btn_8_count ++;
                        int ind = Text.Length - 1;
                        Text = Text.Remove(ind);
                        Text += '9';
                        stopWatch.Reset();
                        stopWatch.Start();
                        return;
                    }
                    else
                    {

                        stopWatch.Reset();
                    }
                }
                else if (Btn_8_count == 5)
                {
                    Btn_8_count = 0;
                }
            });
        }
        #endregion
    }
}
