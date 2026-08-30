using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            AS01_RandomItemDrop();
            AS02_NestedLoopForCreate2DMap();
            AS03_NestedLoopForMakingWallAround();
            AS04_AttackEnemy();
            AS05_DynamicIterationLoop();
            AS06_WhileLoopAndArray();
            AS07_HealTargetAtIndex();
            AS08_RandomPickingDialogue();
            AS09_MultiplicationTable();
            AS10_FindSummationFromZeroToNUsingWhileLoop();
            AS11_SpawnEnemies();
            StartCoroutine(AS12_CountTime());
            AS13_SumOfNumbersInRow();
            AS14_SumOfNumbersInColumn();
            AS15_MakeTheTriangle();
            AS16_MultiplicationTableOf_2_3_and_4();
            EX_01_TicTacToeGame_TurnPlay();
        }

        #region Assignment

        [Header("AS01_RandomItemDrop")]
        public GameObject[] as01_items;
        public void AS01_RandomItemDrop()
        {
            if (as01_items == null || as01_items.Length == 0) return;

            int randomIndex = UnityEngine.Random.Range(0, as01_items.Length);
            GameObject selectedPrefab = as01_items[randomIndex];
            GameObject go = Instantiate(selectedPrefab);
            Debug.Log($"Got item: {go.name}");
        }

        [Header("AS02_NestedLoopForCreate2DMap")]
        public GameObject[] as02_floorTiles;
        public int as02_columns = 5;
        public int as02_rows = 5;
        public void AS02_NestedLoopForCreate2DMap()
        {
            if (as02_floorTiles == null || as02_floorTiles.Length == 0) return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Column ...\n{as02_columns}");
            sb.AppendLine($"Row ...\n{as02_rows}");

            for (int y = 0; y < as02_rows; y++)
            {
                for (int x = 0; x < as02_columns; x++)
                {
                    int randomIndex = UnityEngine.Random.Range(0, as02_floorTiles.Length);
                    GameObject selectedObj = as02_floorTiles[randomIndex];
                    GameObject tile = Instantiate(selectedObj, new Vector2(x, y), transform.rotation);
                    sb.Append(tile.name);
                }
                sb.AppendLine();
            }

            Debug.Log(sb.ToString());
        }

        [Header("AS03_NestedLoopForMakingWallAround")]
        public GameObject as03_wall;
        public int as03_columns = 5;
        public int as03_rows = 5;
        public void AS03_NestedLoopForMakingWallAround()
        {
            if (as03_wall == null) return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Column ...\n{as03_columns}");
            sb.AppendLine($"Row ...\n{as03_rows}");

            // รวมขอบนอกสุด +2 ช่อง (จาก x=-1 ถึง columns และ y=-1 ถึง rows)
            for (int y = -1; y <= as03_rows; y++)
            {
                for (int x = -1; x <= as03_columns; x++)
                {
                    if (x == -1 || x == as03_columns || y == -1 || y == as03_rows)
                    {
                        Instantiate(as03_wall, new Vector2(x, y), transform.rotation);
                        sb.Append("*");
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }
                sb.AppendLine();
            }

            Debug.Log(sb.ToString());
        }

        [Header("AS04_AttackEnemy")]
        public int[] as04_enemyHP;
        public int as04_damage;
        public int as04_target;
        public void AS04_AttackEnemy()
        {
            if (as04_enemyHP == null || as04_enemyHP.Length == 0) return;

            // รูปแบบที่ 1: โจมตีตัวแรก
            as04_enemyHP[0] -= as04_damage;
            Debug.Log($"FirstEnemy hp :{as04_enemyHP[0]}");

            // รูปแบบที่ 2: โจมตีตัวสุดท้าย
            int lastIndex = as04_enemyHP.Length - 1;
            as04_enemyHP[lastIndex] -= as04_damage;
            Debug.Log($"LastEnemy hp :{as04_enemyHP[lastIndex]}");

            // รูปแบบที่ 3: โจมตีเป้าหมายที่กำหนด
            if (as04_target >= 0 && as04_target < as04_enemyHP.Length)
            {
                as04_enemyHP[as04_target] -= as04_damage;
                Debug.Log($"TargetEnemy {as04_target} hp :{as04_enemyHP[as04_target]}");
            }
        }

        [Header("AS05_DynamicIterationLoop")]
        public int as05_n;
        public void AS05_DynamicIterationLoop()
        {
            for (int i = 0; i < as05_n; i++)
            {
                Debug.Log(i);
            }
        }

        [Header("AS06_WhileLoopAndArray")]
        public string[] as06_ironManSuitNames;
        public void AS06_WhileLoopAndArray()
        {
            if (as06_ironManSuitNames == null || as06_ironManSuitNames.Length == 0) return;

            Debug.Log("======Log by One======");
            int i = 0;
            while (i < as06_ironManSuitNames.Length)
            {
                Debug.Log(as06_ironManSuitNames[i]);
                i += 1;
            }

            Debug.Log("======Log by Two======");
            i = 0;
            while (i < as06_ironManSuitNames.Length)
            {
                Debug.Log(as06_ironManSuitNames[i]);
                i += 2;
            }
        }

        [Header("AS07_HealTargetAtIndex")]
        public int[] as07_heroHPs;
        public int as07_heal;
        public int as07_targetIndex;
        public void AS07_HealTargetAtIndex()
        {
            if (as07_heroHPs == null || as07_heroHPs.Length == 0) return;

            // รูปแบบที่ 1: Heal ตัวแรก
            as07_heroHPs[0] += as07_heal;
            Debug.Log($"FirstHero hp :{as07_heroHPs[0]}");

            // รูปแบบที่ 2: Heal ตัวสุดท้าย
            int lastIndex = as07_heroHPs.Length - 1;
            as07_heroHPs[lastIndex] += as07_heal;
            Debug.Log($"LastHero hp :{as07_heroHPs[lastIndex]}");

            // รูปแบบที่ 3: Heal ตัวเป้าหมายที่กำหนด
            if (as07_targetIndex >= 0 && as07_targetIndex < as07_heroHPs.Length)
            {
                as07_heroHPs[as07_targetIndex] += as07_heal;
                Debug.Log($"TargetHero {as07_targetIndex} hp :{as07_heroHPs[as07_targetIndex]}");
            }
        }

        [Header("AS08_RandomPickingDialogue")]
        public string[] as08_dialogues;
        public void AS08_RandomPickingDialogue()
        {
            if (as08_dialogues == null || as08_dialogues.Length == 0) return;

            int r = UnityEngine.Random.Range(0, as08_dialogues.Length);
            Debug.Log(as08_dialogues[r]);
        }

        [Header("AS09_MultiplicationTable")]
        public int as09_n;
        public void AS09_MultiplicationTable()
        {
            for (int i = 1; i <= 12; i++)
            {
                Debug.Log($"{as09_n}x{i}={as09_n * i}");
            }
        }

        [Header("AS10_FindSummationFromZeroToNUsingWhileLoop")]
        public int as10_n;
        public void AS10_FindSummationFromZeroToNUsingWhileLoop()
        {
            int sum = 0;
            int i = 1;
            while (i <= as10_n)
            {
                sum += i;
                i++;
            }
            Debug.Log($"ผลรวมของ n จาก 1 ถึง {as10_n} คือ {sum}");
        }

        [Header("AS11_SpawnEnemies")]
        public int[] as11_enemyHPs;
        public GameObject as11_enemyPrefab;
        public void AS11_SpawnEnemies()
        {
            if (as11_enemyPrefab == null || as11_enemyHPs == null) return;

            for (int i = 0; i < as11_enemyHPs.Length; i++)
            {
                Vector3 spawnPos = transform.position + new Vector3(i + 1, 0, 0);
                Instantiate(as11_enemyPrefab, spawnPos, transform.rotation);
            }
        }

        [Header("AS12_CountTime")]
        public float as12_countTime;
        public IEnumerator AS12_CountTime()
        {
            float timer = as12_countTime;
            while (timer > 0)
            {
                Debug.Log($"Time remaining: {timer:F1}s");
                yield return new WaitForSeconds(1f);
                timer -= 1f;
            }
            Debug.Log("Time's up!");
        }

        [Header("AS13_SumOfNumbersInRow")]
        public Grid2DInt as13_matrix = new Grid2DInt
        {
            rows = 3,
            cols = 3,
            data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
        };
        public int as13_row;
        public void AS13_SumOfNumbersInRow()
        {
            var matrix = as13_matrix.Get2DArray();
            int sum = 0;

            if (as13_row >= 0 && as13_row < matrix.GetLength(0))
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[as13_row, col];
                }
            }

            Debug.Log($"Row ...\n{as13_row}\n{sum}");
        }

        [Header("AS14_SumOfNumbersInColumn")]
        public Grid2DInt as14_matrix = new Grid2DInt
        {
            rows = 3,
            cols = 3,
            data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
        };
        public int as14_column;
        public void AS14_SumOfNumbersInColumn()
        {
            var matrix = as14_matrix.Get2DArray();
            int sum = 0;

            if (as14_column >= 0 && as14_column < matrix.GetLength(1))
            {
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    sum += matrix[r, as14_column];
                }
            }

            Debug.Log($"Col ...\n{as14_column}\n{sum}");
        }

        [Header("AS15_MakeTheTriangle")]
        public int as15_size = 5;
        public void AS15_MakeTheTriangle()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Size ...\n{as15_size}");

            for (int i = 1; i <= as15_size; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    sb.Append("*");
                }
                sb.AppendLine();
            }

            Debug.Log(sb.ToString());
        }

        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= 12; i++)
            {
                for (int m = 2; m <= 4; m++)
                {
                    sb.Append($"{m} x {i} = {m * i}");
                    if (m < 4)
                    {
                        sb.Append("\t");
                    }
                }
                if (i < 12)
                {
                    sb.AppendLine();
                }
            }

            Debug.Log(sb.ToString());
        }

        #endregion

        #region Extra assignment

        [Header("EX_01_TicTacToeGame_TurnPlay")]
        public Grid2DString ex01_board = new Grid2DString
        {
            rows = 3,
            cols = 3,
            data = new string[] {
                "X", "X", "O",
                "X", "O", "X",
                "", "", ""
            }
        };
        public string ex01_playerTurn = "O";
        public int ex01_row = 2;
        public int ex01_column = 0;
        public void EX_01_TicTacToeGame_TurnPlay()
        {
            var board = ex01_board.Get2DArray();

            // 1. ตรวจสอบการเดินว่าถูกต้องหรือไม่ (Invalid move)
            if (ex01_row < 0 || ex01_row >= 3 || ex01_column < 0 || ex01_column >= 3 || !string.IsNullOrEmpty(board[ex01_row, ex01_column]))
            {
                PrintBoard(board);
                Debug.Log($">> Invalid move");
                return;
            }

            // 2. วางหมากของผู้เล่นลงกระดาน
            board[ex01_row, ex01_column] = ex01_playerTurn;
            PrintBoard(board);

            // 3. ตรวจสอบผู้ชนะ
            if (CheckWin(board, ex01_playerTurn))
            {
                Debug.Log($">> {ex01_playerTurn} wins!");
                return;
            }

            // 4. ตรวจสอบกระดานเต็ม (Draw)
            if (IsBoardFull(board))
            {
                Debug.Log(">> Draw");
                return;
            }

            // 5. เกมดำเนินต่อ
            Debug.Log(">> Continue");
        }

        private bool CheckWin(string[,] board, string player)
        {
            // เช็คแถวและคอลัมน์
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) return true;
                if (board[0, i] == player && board[1, i] == player && board[2, i] == player) return true;
            }

            // เช็คเส้นทะแยงมุม
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) return true;
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) return true;

            return false;
        }

        private bool IsBoardFull(string[,] board)
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (string.IsNullOrEmpty(board[r, c])) return false;
                }
            }
            return true;
        }

        #endregion

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine("| " + spaceIfEmpty(board[i, 0]) + " | " + spaceIfEmpty(board[i, 1]) + " | " + spaceIfEmpty(board[i, 2]) + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }

        private string spaceIfEmpty(string value)
        {
            return string.IsNullOrEmpty(value) ? " " : value;
        }
    }
}