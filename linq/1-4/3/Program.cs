﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{
	class Program
	{
        private const int MAX_X = 9;
        private const int MAX_Y = 9;
        private const int WIN_COUNT = 3;
        private static char[,] _playground = new char[MAX_X, MAX_Y];

        private static bool _firstPlayerPlaying = true;
        private static bool _gameOver = false;

 		static void Main(string[] args) {
            Init();
            while(true){
                Tick();
            }
		}

        private static void Init(){
            for (int i = 0; i < MAX_X; i++)
            {
                for (int j = 0; j < MAX_Y; j++)
                {
                    _playground[i,j] = ' ';
                }
            }

            Draw();
        }

        private static void Tick(){
            if(_gameOver)
                return;

            Console.WriteLine();
            var playerText = _firstPlayerPlaying? "kolečky" : "křížky";
            Console.WriteLine($"Na řadě je hráč s {playerText}");

            var inputs = GetInputs();

            var symbol = _firstPlayerPlaying? 'X' : 'O';

            _playground[inputs.Item2, inputs.Item1] = symbol;

            var win = CheckWin(symbol);

            if(win){
                Draw();
                Console.WriteLine($"Vyhrál hráč s {playerText}");
                _gameOver = true;
                return;
            }
            else{
            _firstPlayerPlaying =  !_firstPlayerPlaying;
            Draw();
            }


        }

        private static bool CheckWin(char symbol){
            //lines
            for (int i = 0; i  < MAX_X; i ++)
            {
                var count = 0;
                for (int j = 0; j < MAX_Y; j++)
                {
                    if(j == 0){
                        if(_playground[i, j] == symbol)
                        count++;
                    }
                    else{
                        if(_playground[i, j] == symbol && _playground[i, j-1] == symbol)
                        count++;
                        else
                        count = _playground[i, j] == symbol? 1 : 0;
                    }                    
                    if(count >= WIN_COUNT)
                        return true;
                }
            }

            //columns
            for (int i = 0; i  < MAX_X; i ++)
            {
                var count = 0;
                for (int j = 0; j < MAX_Y; j++)
                {
                    if(j == 0){
                        if(_playground[j, i] == symbol)
                        count++;
                    }
                    else{
                        if(_playground[j, i] == symbol && _playground[j-1, i] == symbol)
                        count++;
                        else
                        count = _playground[j, i] == symbol? 1 : 0;
                    }                    
                    if(count >= WIN_COUNT)
                        return true;
                }
            }

            return false;
        }

        private static (int,int) GetInputs(){

            int x,y = 0;

            Console.Write("Zadej pozici X kam chceš táhnout: ");
            while(true){
                var stringX = Console.ReadLine();
                
                if(int.TryParse(stringX, out x)){
                    break;
                }
                else{
                    Console.WriteLine("Zadej prosím celé číslo");
                }
            }

            Console.Write("Zadej pozici Y kam chceš táhnout: ");
            while(true){
                var stringY = Console.ReadLine();
                
                if(int.TryParse(stringY, out y)){
                    break;
                }
                else{
                    Console.WriteLine("Zadej prosím celé číslo");
                }
            }

            x--;
            y--;

            if(x < 0 || x > 8 || y<0 || y > 8 || _playground[x,y] != ' '){
                Console.WriteLine("Neplatná pozice, zadej ji prosím znovu.");
                return GetInputs();
            }

            return (x,y);
        }

        private static void Draw(){
            Console.Clear();
            Console.WriteLine("  123456789");

            for (int i = 0; i < MAX_Y; i++)
            {
                Console.WriteLine($"{i+1} {GetLineString(i)}");
            }
        }

        private static string GetLineString(int line){
            var sb  = new StringBuilder();

            for (int i = 0; i < MAX_Y; i++)
            {
                sb.Append(_playground[line, i]);
            }

            return sb.ToString();
        }
	}
}
