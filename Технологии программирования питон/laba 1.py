import re
from datetime import datetime
from dataclasses import dataclass

@dataclass
class CurrencyCourse:
    name: str
    code: str
    rate: float
    date: datetime.date

class CurrencyParser:
    @staticmethod
    def parse_line(line: str) -> CurrencyCourse:
        # Регулярное выражение для поиска:
        # 1. Текста в кавычках: "([^"]*)"
        # 2. Чисел: (\d+\.?\d*)
        # 3. Даты: (\\d{4}\.\d{2}\.\d{2})
        pattern = r'"([^"]*)"\s+"([^"]*)"\s+(\d+\.?\d*)\s+(\d{4}\.\d{2}\.\d{2})'
        match = re.search(pattern, line)
        
        if match:
            return CurrencyCourse(
                name=match.group(1),
                code=match.group(2),
                rate=float(match.group(3)),
                date=datetime.strptime(match.group(4), "%Y.%m.%d").date()
            )
        return None