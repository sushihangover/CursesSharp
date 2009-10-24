#region Copyright 2009 Robert Konklewski

/*
 * UnicodeDemo. A test program for CursesSharp.
 * 
 * Copyright 2009 Robert Konklewski
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 */

#endregion

using System;
using CursesSharp;

namespace UnicodeDemo
{
    class Program: IDisposable
    {
        static void Main(string[] args)
        {
            using (Program prg = new Program())
            {
                prg.Run();
            }
        }

        /// <summary>
        /// From Wikipedia: http://en.wikipedia.org/wiki/List_of_pangrams
        /// </summary>
        private static string[] TEXT_LINES = 
        {
            "Под южно дърво, цъфтящо в синьо, бягаше малко пухкаво зайче.",
            "Příliš žluťoučký kůň úpěl ďábelské ódy.",
            "視野無限廣，窗外有藍天 ",
            "Quizdeltagerne spiste jordbær med fløde, mens cirkusklovnen Walther spillede på xylofon.",
            "Pa's wijze lynx bezag vroom het fikse aquaduct.",
            "Eĥoŝanĝo ĉiuĵaŭde.",
            "See väike mölder jõuab rongile hüpata",
            "Viekas kettu punaturkki laiskan koiran takaa kurkki.",
            "Voix ambiguë d'un cœur qui au zéphyr préfère les jattes de kiwis.",
            "Portez ce vieux whisky au juge blond qui fume.",
            "Zwölf Boxkämpfer jagen Viktor quer über den großen Sylter Deich",
            "Θέλει αρετή και τόλμη η ελευθερία. (Ανδρέας Κάλβος)",
            "דג סקרן שט לו בים זך אך לפתע פגש חבורה נחמדה שצצה כך",
            "Egy hűtlen vejét fülöncsípő, dühös mexikói úr Wesselényinél mázol Quitóban.",
            "Ma la volpe, col suo balzo, ha raggiunto il quieto Fido.",
            "いろはにほへと ちりぬるを わかよたれそ つねならむ うゐのおくやま けふこえて あさきゆめみし ゑひもせす",
            "다람쥐 헌 쳇바퀴에 타고파",
            "Sarkanās jūrascūciņas peld pa jūru.",
            "En god stil må først og fremst være klar. Den må være passende. Aristoteles.",
            "A rápida raposa castanha salta por cima do cão lento.",
            "A ligeira raposa marrom ataca o cão preguiçoso.",
            "Zebras caolhas de Java querem passar fax para moças gigantes de New York",
            "Pchnąć w tę łódź jeża lub ośm skrzyń fig",
            "Agera vulpe maronie sare peste câinele cel leneş.",
            "Съешь ещё этих мягких французских булок да выпей же чаю",
            "Чешће цeђење мрeжастим џаком побољшава фертилизацију генских хибрида.",
            "Češće ceđenje mrežastim džakom poboljšava fertilizaciju genskih hibrida.",
            "Kŕdeľ šťastných ďatľov učí pri ústí Váhu mĺkveho koňa obhrýzať kôru a žrať čerstvé mäso.",
            "V kožuščku hudobnega fanta stopiclja mizar in kliče 0619872345.",
            "El veloz murciélago hindú comía feliz cardillo y kiwi. La cigüeña tocaba el saxofón detrás del palenque de paja.",
            "Flygande bäckasiner söka strax hwila på mjuka tuvor",
            "เป็นมนุษย์สุดประเสริฐเลิศคุณค่า กว่าบรรดาฝูงสัตว์เดรัจฉาน จงฝ่าฟันพัฒนาวิชาการ อย่าล้างผลาญฤๅเข่นฆ่าบีฑาใคร ไม่ถือโทษโกรธแช่งซัดฮึดฮัดด่า หัดอภัยเหมือนกีฬาอัชฌาสัย ปฏิบัติประพฤติกฎกำหนดใจ พูดจาให้จ๊ะ ๆ จ๋า ๆ น่าฟังเอยฯ",
            "Pijamalı hasta, yağız şoföre çabucak güvendi"
        };

        private readonly Random rng;
        private readonly int linecount;
        private readonly int colcount;

        private string[] lines;
        private int[] offsets;

        public Program()
        {
            this.rng = new Random();
            Curses.InitScr();
            this.linecount = Curses.Lines;
            this.colcount = Curses.Cols;
            this.lines = new string[linecount];
            this.offsets = new int[linecount];
        }

        #region IDisposable Members

        public void Dispose()
        {
            Curses.EndWin();
        }

        #endregion

        private void Run()
        {
            Initialize();
            while (true)
            {
                for (int i = 0; i < lines.Length; ++i)
                {
                    if (offsets[i] <= 0)
                    {
                        lines[i] = null;
                        offsets[i] = 0;
                    }
                    if (lines[i] == null)
                    {
                        lines[i] = TEXT_LINES[rng.Next(TEXT_LINES.Length)];
                        offsets[i] = colcount + lines[i].Length;
                    }
                    Stdscr.Move(i, 0);
                    Stdscr.ClearToEol();
                    int of = colcount - offsets[i];
                    string str = lines[i];
                    if (of < 0)
                    {
                        str = str.Substring(-of, str.Length + of);
                        of = 0;
                    }
                    else
                    {
                        int ln = Math.Min(offsets[i], str.Length);
                        str = str.Substring(0, ln);
                    }
                    Stdscr.Insert(i, of, str);
                    offsets[i]--;
                }

                switch (Stdscr.GetChar())
                {
                    case 'q':
                    case 'Q':
                        Curses.CursorVisibility = 1;
                        return;
                    default: break;
                }
                Curses.NapMs(100);
            }
        }

        private void Initialize()
        {
            Curses.Newlines = true;
            Curses.Echo = false;
            Curses.CursorVisibility = 0;
            Stdscr.ReadTimeout = 0;
            Stdscr.Keypad = true;
        }
    }
}
