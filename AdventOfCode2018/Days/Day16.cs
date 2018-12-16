using AdventOfCode2018.Commons;
using AdventOfCode2018.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Days
{
    class Day16
    {
        public void Part1()
        {
            List<OpCodeOperation> opCodeOperations = new FileRead().GetOpCodeOperations("../../../Inputs/Day16_1.txt");
            int count = 0;

            foreach(OpCodeOperation opCodeOperation in opCodeOperations)
            {
                int countMatch = 0;
                countMatch += AddrCheck(opCodeOperation);
                countMatch += AddiCheck(opCodeOperation);
                countMatch += MulrCheck(opCodeOperation);
                countMatch += MuliCheck(opCodeOperation);
                countMatch += BarrCheck(opCodeOperation);
                countMatch += BariCheck(opCodeOperation);
                countMatch += BorrCheck(opCodeOperation);
                countMatch += BoriCheck(opCodeOperation);

                countMatch += SetrCheck(opCodeOperation);
                countMatch += SetiCheck(opCodeOperation);
                countMatch += GtirCheck(opCodeOperation);
                countMatch += GtriCheck(opCodeOperation);
                countMatch += GtrrCheck(opCodeOperation);
                countMatch += EqirCheck(opCodeOperation);
                countMatch += EqriCheck(opCodeOperation);
                countMatch += EqrrCheck(opCodeOperation);

                if (countMatch >= 3)
                {
                    count++;
                }
            }
            Console.WriteLine("End result of day 16 (part 1) is " + count); //640
        }

        public void Part2()
        {
            List<OpCodeOperation> opCodeOperations = new FileRead().GetOpCodeOperations("../../../Inputs/Day16_1.txt");
            List<int[]> programLines = new FileRead().GetProgramLines("../../../Inputs/Day16_2.txt");
            IDictionary<int, HashSet<int>> matches = new Dictionary<int, HashSet<int>>();
            IDictionary<int, Action< int[], int[]>> functions = new Dictionary<int, Action<int[], int[]>>();
            int instNum = 16;

            for (int index = 1; index <= instNum; index++)
            {
                matches[index] = new HashSet<int>();
            }
            
            foreach (OpCodeOperation opCodeOperation in opCodeOperations)
            {
                if (AddrCheck(opCodeOperation) == 1) { matches[1].Add(opCodeOperation.Operation[0]); }
                if (AddiCheck(opCodeOperation) == 1) { matches[2].Add(opCodeOperation.Operation[0]); }
                if (MulrCheck(opCodeOperation) == 1) { matches[3].Add(opCodeOperation.Operation[0]); }
                if (MuliCheck(opCodeOperation) == 1) { matches[4].Add(opCodeOperation.Operation[0]); }
                if (BarrCheck(opCodeOperation) == 1) { matches[5].Add(opCodeOperation.Operation[0]); }
                if (BariCheck(opCodeOperation) == 1) { matches[6].Add(opCodeOperation.Operation[0]); }
                if (BorrCheck(opCodeOperation) == 1) { matches[7].Add(opCodeOperation.Operation[0]); }
                if (BoriCheck(opCodeOperation) == 1) { matches[8].Add(opCodeOperation.Operation[0]); }
                if (SetrCheck(opCodeOperation) == 1) { matches[9].Add(opCodeOperation.Operation[0]); }
                if (SetiCheck(opCodeOperation) == 1) { matches[10].Add(opCodeOperation.Operation[0]); }
                if (GtirCheck(opCodeOperation) == 1) { matches[11].Add(opCodeOperation.Operation[0]); }
                if (GtriCheck(opCodeOperation) == 1) { matches[12].Add(opCodeOperation.Operation[0]); }
                if (GtrrCheck(opCodeOperation) == 1) { matches[13].Add(opCodeOperation.Operation[0]); }
                if (EqirCheck(opCodeOperation) == 1) { matches[14].Add(opCodeOperation.Operation[0]); }
                if (EqriCheck(opCodeOperation) == 1) { matches[15].Add(opCodeOperation.Operation[0]); }
                if (EqrrCheck(opCodeOperation) == 1) { matches[16].Add(opCodeOperation.Operation[0]); }
            }

            while (true)
            {
                int func = -1;
                for (int index = 1; index <= instNum; index++)
                {
                    if (matches[index].Count == 1)
                    {
                        func = matches[index].ToList()[0];
                        if (index == 1) { functions[func] = Addr; break; }
                        else if (index == 2) { functions[func] = Addi; break; }
                        else if (index == 3) { functions[func] = Mulr; break; }
                        else if (index == 4) { functions[func] = Muli; break; }
                        else if (index == 5) { functions[func] = Barr; break; }
                        else if (index == 6) { functions[func] = Bari; break; }
                        else if (index == 7) { functions[func] = Borr; break; }
                        else if (index == 8) { functions[func] = Bori; break; }
                        else if (index == 9) { functions[func] = Setr; break; }
                        else if (index == 10) { functions[func] = Seti; break; }
                        else if (index == 11) { functions[func] = Gtir; break; }
                        else if (index == 12) { functions[func] = Gtri; break; }
                        else if (index == 13) { functions[func] = Gtrr; break; }
                        else if (index == 14) { functions[func] = Eqir; break; }
                        else if (index == 15) { functions[func] = Eqri; break; }
                        else if (index == 16) { functions[func] = Eqrr; break; }
                    }
                }

                if (func == -1) { break; }

                for (int index = 1; index <= 16; index++)
                {
                    matches[index].Remove(func);
                }
            }

            int[] registers = { 0, 0, 0, 0 };
            foreach (int[] line in programLines)
            {
                functions[line[0]](registers, line);
            }

            Console.WriteLine("End result of day 16 (part 2) is " + registers[0]); //472
        }

        private void Addr(int[] registers, int[] operation)
        {
            /*
             * addr (add register) stores into register C the result of adding register A and register B.
             */
            registers[operation[3]] = registers[operation[1]] + registers[operation[2]];
        }

        private void Addi(int[] registers, int[] operation)
        {
            /*
             * addi (add immediate) stores into register C the result of adding register A and value B.
             */
            registers[operation[3]] = registers[operation[1]] + operation[2];
        }

        private void Mulr(int[] registers, int[] operation)
        {
            /*
             * mulr (multiply register) stores into register C the result of multiplying register A and register B.
             */
            registers[operation[3]] = registers[operation[1]] * registers[operation[2]];
        }

        private void Muli(int[] registers, int[] operation)
        {
            /*
             * muli (multiply immediate) stores into register C the result of multiplying register A and value B.
             */
            registers[operation[3]] = registers[operation[1]] * operation[2];
        }

        private void Barr(int[] registers, int[] operation)
        {
            /*
             * banr (bitwise AND register) stores into register C the result of the bitwise AND of register A and register B.
             */
            registers[operation[3]] = (registers[operation[1]] & registers[operation[2]]);
        }

        private void Bari(int[] registers, int[] operation)
        {
            /*
             * bani (bitwise AND immediate) stores into register C the result of the bitwise AND of register A and value B.
             */
            registers[operation[3]] = (registers[operation[1]] & operation[2]);
        }

        private void Borr(int[] registers, int[] operation)
        {
            /*
             * borr (bitwise OR register) stores into register C the result of the bitwise OR of register A and register B.
             */
            registers[operation[3]] = (registers[operation[1]] | registers[operation[2]]);
        }

        private void Bori(int[] registers, int[] operation)
        {
            /*
             * bori (bitwise OR immediate) stores into register C the result of the bitwise OR of register A and value B.
             */
            registers[operation[3]] = (registers[operation[1]] | operation[2]);
        }

        private void Setr(int[] registers, int[] operation)
        {
            /*
             * setr (set register) copies the contents of register A into register C. (Input B is ignored.)
             */
            registers[operation[3]] = registers[operation[1]];
        }

        private void Seti(int[] registers, int[] operation)
        {
            /*
             * seti (set immediate) stores value A into register C. (Input B is ignored.)
             */
            registers[operation[3]] = operation[1];
        }

        private void Gtir(int[] registers, int[] operation)
        {
            /*
             * (greater-than immediate/register) sets register C to 1 if value A is greater than register B. Otherwise, register C is set to 0.
             */
            registers[operation[3]] = operation[1] > registers[operation[2]] ? 1 : 0;
        }

        private void Gtri(int[] registers, int[] operation)
        {
            /*
             * gtri (greater-than register/immediate) sets register C to 1 if register A is greater than value B. Otherwise, register C is set to 0.
             */
            registers[operation[3]] = operation[2] < registers[operation[1]] ? 1 : 0;
        }

        private void Gtrr(int[] registers, int[] operation)
        {
            /*
             * gtrr (greater-than register/register) sets register C to 1 if register A is greater than register B. Otherwise, register C is set to 0.*/
            registers[operation[3]] = registers[operation[1]] > registers[operation[2]] ? 1 : 0;
        }

        private void Eqir(int[] registers, int[] operation)
        {
            /*
             * eqir (equal immediate/register) sets register C to 1 if value A is equal to register B. Otherwise, register C is set to 0.
             */
            registers[operation[3]] = operation[1] == registers[operation[2]] ? 1 : 0;
        }

        private void Eqri(int[] registers, int[] operation)
        {
            /*
             * eqri (equal register/immediate) sets register C to 1 if register A is equal to value B. Otherwise, register C is set to 0.
             */
            registers[operation[3]] = operation[2] == registers[operation[1]] ? 1 : 0;
        }

        private void Eqrr(int[] registers, int[] operation)
        {
            /*
             * eqrr (equal register/register) sets register C to 1 if register A is equal to register B. Otherwise, register C is set to 0.
             */
            registers[operation[3]] = registers[operation[1]] == registers[operation[2]] ? 1 : 0;
        }






        private int AddrCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * addr (add register) stores into register C the result of adding register A and register B.
             */
            return opCodeOperation.After[opCodeOperation.Operation[3]] == opCodeOperation.Before[opCodeOperation.Operation[1]] +
                opCodeOperation.Before[opCodeOperation.Operation[2]] ? 1 : 0;
        }

        private int AddiCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * addi (add immediate) stores into register C the result of adding register A and value B.
             */
            return opCodeOperation.After[opCodeOperation.Operation[3]] == opCodeOperation.Before[opCodeOperation.Operation[1]] +
                opCodeOperation.Operation[2] ? 1 : 0;
        }

        private int MulrCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * mulr (multiply register) stores into register C the result of multiplying register A and register B.
             */
            return opCodeOperation.After[opCodeOperation.Operation[3]] == opCodeOperation.Before[opCodeOperation.Operation[1]] *
                opCodeOperation.Before[opCodeOperation.Operation[2]] ? 1 : 0;
        }

        private int MuliCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * muli (multiply immediate) stores into register C the result of multiplying register A and value B.
             */
            return opCodeOperation.After[opCodeOperation.Operation[3]] == opCodeOperation.Before[opCodeOperation.Operation[1]] *
                opCodeOperation.Operation[2] ? 1 : 0;
        }

        private int BarrCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * banr (bitwise AND register) stores into register C the result of the bitwise AND of register A and register B.
             */
            return opCodeOperation.After[opCodeOperation.Operation[3]] == (opCodeOperation.Before[opCodeOperation.Operation[1]] &
                 opCodeOperation.Before[opCodeOperation.Operation[2]]) ? 1 : 0;
        }

        private int BariCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * bani (bitwise AND immediate) stores into register C the result of the bitwise AND of register A and value B.
             */
            return opCodeOperation.After[opCodeOperation.Operation[3]] == (opCodeOperation.Before[opCodeOperation.Operation[1]] &
               opCodeOperation.Operation[2]) ? 1 : 0;
        }

        private int BorrCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * borr (bitwise OR register) stores into register C the result of the bitwise OR of register A and register B.
             */
            return opCodeOperation.After[opCodeOperation.Operation[3]] == (opCodeOperation.Before[opCodeOperation.Operation[1]] |
                 opCodeOperation.Before[opCodeOperation.Operation[2]]) ? 1 : 0;
        }

        private int BoriCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * bori (bitwise OR immediate) stores into register C the result of the bitwise OR of register A and value B.
             */
            return opCodeOperation.After[opCodeOperation.Operation[3]] == (opCodeOperation.Before[opCodeOperation.Operation[1]] |
              opCodeOperation.Operation[2]) ? 1 : 0;
        }

        private int SetrCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * setr (set register) copies the contents of register A into register C. (Input B is ignored.)
             */
            return opCodeOperation.After[opCodeOperation.Operation[3]] == opCodeOperation.Before[opCodeOperation.Operation[1]] ? 1 : 0;
        }

        private int SetiCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * seti (set immediate) stores value A into register C. (Input B is ignored.)
             */
            return opCodeOperation.After[opCodeOperation.Operation[3]] == opCodeOperation.Operation[1] ? 1 : 0;
        }

        private int GtirCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * (greater-than immediate/register) sets register C to 1 if value A is greater than register B. Otherwise, register C is set to 0.
             */
            if (opCodeOperation.Operation[1] > opCodeOperation.Before[opCodeOperation.Operation[2]])
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 1 ? 1 : 0;
            else
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 0 ? 1 : 0;
        }

        private int GtriCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * gtri (greater-than register/immediate) sets register C to 1 if register A is greater than value B. Otherwise, register C is set to 0.
             */
            if (opCodeOperation.Operation[2] < opCodeOperation.Before[opCodeOperation.Operation[1]])
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 1 ? 1 : 0;
            else
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 0 ? 1 : 0;
        }

        private int GtrrCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * gtrr (greater-than register/register) sets register C to 1 if register A is greater than register B. Otherwise, register C is set to 0.*/
            if (opCodeOperation.Before[opCodeOperation.Operation[1]] > opCodeOperation.Before[opCodeOperation.Operation[2]])
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 1 ? 1 : 0;
            else
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 0 ? 1 : 0;
        }

        private int EqirCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * eqir (equal immediate/register) sets register C to 1 if value A is equal to register B. Otherwise, register C is set to 0.
             */
            if (opCodeOperation.Operation[1] == opCodeOperation.Before[opCodeOperation.Operation[2]])
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 1 ? 1 : 0;
            else
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 0 ? 1 : 0;
        }

        private int EqriCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * eqri (equal register/immediate) sets register C to 1 if register A is equal to value B. Otherwise, register C is set to 0.
             */
            if (opCodeOperation.Operation[2] == opCodeOperation.Before[opCodeOperation.Operation[1]])
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 1 ? 1 : 0;
            else
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 0 ? 1 : 0;
        }

        private int EqrrCheck(OpCodeOperation opCodeOperation)
        {
            /*
             * eqrr (equal register/register) sets register C to 1 if register A is equal to register B. Otherwise, register C is set to 0.
             */
            if (opCodeOperation.Before[opCodeOperation.Operation[1]] == opCodeOperation.Before[opCodeOperation.Operation[2]])
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 1 ? 1 : 0;
            else
                return opCodeOperation.After[opCodeOperation.Operation[3]] == 0 ? 1 : 0;
        }
    }
}