import unittest
import os
from Olimpiada import solve

class TestSkiRelay(unittest.TestCase):

    def run_test_case(self, n, d, a_times, b_times):
        current_dir = os.path.dirname(os.path.abspath(__file__))
        input_path = os.path.join(current_dir, 'INPUT.TXT')
        output_path = os.path.join(current_dir, 'OUTPUT.TXT')

        with open(input_path, 'w', encoding='utf-8') as f:
            f.write(f"{n}\n{d}\n")
            for t in a_times: f.write(f"{t}\n")
            for t in b_times: f.write(f"{t}\n")
        
        solve()
        
        if not os.path.exists(output_path):
            raise FileNotFoundError(f"Файл {output_path} не был создан!")
            
        with open(output_path, 'r', encoding='utf-8') as f:
            content = f.read().strip()
            return int(float(content))

    def test_example_1(self):
        """Тест из картинки №1 (Ответ должен быть 13)"""
        n, d = 5, 5
        a = [0, 3, 7, 8, 14]
        b = [2, 3, 11, 13, 20]
        self.assertEqual(self.run_test_case(n, d, a, b), 13)

    def test_example_2(self):
        """Тест из картинки №2 (Ответ должен быть 24)"""
        n, d = 6, 10
        a = [5, 6, 7, 8, 9, 10]
        b = [14, 15, 16, 17, 18, 19]
        self.assertEqual(self.run_test_case(n, d, a, b), 24)

    def test_simple_reach(self):
        """Простой случай: A1 доносит флаг без встреч"""
        self.assertEqual(self.run_test_case(1, 10, [0], [11]), 10)

    def test_single_meeting(self):
        """Одна встреча: A1 и B1 встречаются, B1 несет в пункт A"""
        self.assertEqual(self.run_test_case(1, 10, [0], [0]), 10)

    def test_late_start_b(self):
        """Случай, когда команда B стартует очень поздно"""
        self.assertEqual(self.run_test_case(2, 100, [0, 10], [1000, 1010]), 100)

if __name__ == '__main__':
    unittest.main()