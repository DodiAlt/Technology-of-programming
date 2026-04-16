import sys
import os

def solve():
    # Настройка путей
    current_dir = os.path.dirname(os.path.abspath(__file__))
    input_path = os.path.join(current_dir, 'INPUT.TXT')
    output_path = os.path.join(current_dir, 'OUTPUT.TXT')

    if not os.path.exists(input_path): return

    # БЫСТРОЕ ЧТЕНИЕ: читаем всё сразу
    with open(input_path, 'r') as f:
        data = f.read().split()

    if not data: return
    
    n = int(data[0])
    d = int(data[1])
    # Превращаем в числа один раз через map (быстрее циклов)
    times = list(map(int, data[2:]))
    a_starts = times[:n]
    b_starts = times[n:]

    curr_pos = 0.0      
    curr_time = float(a_starts[0]) 
    direction = 1       # 1: A -> B, -1: B -> A
    total_path = 0.0
    
    idx_a = 1 
    idx_b = 0

    # ОСНОВНОЙ ЦИКЛ ОПТИМИЗИРОВАН ДО O(N)
    while True:
        if direction == 1:
            # Флаг у лыжника A, ищем встречу ТОЛЬКО с текущим лыжником из B
            if idx_b < n:
                t_start_b = b_starts[idx_b]
                start_m = max(curr_time, t_start_b)
                
                # Расстояние между флагом и B_idx в момент, когда оба на трассе
                dist_flag = curr_pos + (start_m - curr_time)
                dist_b = d - (start_m - t_start_b)
                
                # Время до встречи с момента start_m (скорость сближения = 2)
                time_to_meet = (dist_b - dist_flag) / 2.0
                meeting_time = start_m + time_to_meet
                meeting_pos = dist_flag + time_to_meet
                
                # Если встреча произойдет до того, как флаг достигнет точки D
                if meeting_pos < d:
                    total_path += (meeting_pos - curr_pos)
                    curr_pos = meeting_pos
                    curr_time = meeting_time
                    direction = -1
                    idx_b += 1 # Флаг перешел к этому лыжнику B
                    continue

            # Если встреч нет или они за пределами трассы — финишируем в B
            total_path += (d - curr_pos)
            break
            
        else:
            # Флаг у лыжника B, ищем встречу ТОЛЬКО с текущим из A
            if idx_a < n:
                t_start_a = a_starts[idx_a]
                start_m = max(curr_time, t_start_a)
                
                dist_flag = curr_pos - (start_m - curr_time)
                dist_a = 0 + (start_m - t_start_a)
                
                time_to_meet = (dist_flag - dist_a) / 2.0
                meeting_time = start_m + time_to_meet
                meeting_pos = dist_flag - time_to_meet
                
                if meeting_pos > 0:
                    total_path += (curr_pos - meeting_pos)
                    curr_pos = meeting_pos
                    curr_time = meeting_time
                    direction = 1
                    idx_a += 1
                    continue

            total_path += curr_pos
            break

    # ЗАПИСЬ
    with open(output_path, 'w') as f:
        # Используем format или f-строку для исключения научной нотации у больших чисел
        f.write(f"{total_path:.0f}\n")

if __name__ == "__main__":
    solve()