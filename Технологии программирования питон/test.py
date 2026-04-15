import pytest
from laba_1 import CurrencyParser, CurrencyCourse

def test_parsing_valid_string():
    """Тест: Корректная строка должна превратиться в объект."""
    line = '"USD" "RUB" 75.5 2026.04.14'
    obj = CurrencyParser.parse_line(line)
    
    assert obj.base_currency == "USD"
    assert obj.target_currency == "RUB"
    assert obj.rate == 75.5
    assert obj.date == "2026.04.14"

def test_parsing_invalid_format():
    """Тест: Ошибка формата должна вызывать ValueError (Задание 3)."""
    invalid_line = 'Неправильная строка без кавычек'
    with pytest.raises(ValueError):
        CurrencyParser.parse_line(invalid_line)

def test_invalid_date():
    """Тест: Неправильная дата (гг.мм.дд вместо гггг.мм.дд)."""
    line = '"USD" "RUB" 75.5 26.04.14'
    with pytest.raises(ValueError):
        CurrencyParser.parse_line(line)

def test_rate_not_a_number():
    """Тест: Если в курсе буквы вместо цифр."""
    line = '"USD" "RUB" "МНОГО" 2026.04.14'
    with pytest.raises(ValueError):
        CurrencyParser.parse_line(line)