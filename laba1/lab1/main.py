def bubble_sort(arr):
    n = len(arr)
    for i in range(n):
        for j in range(0, n-i-1):
            if arr[j] > arr[j+1]:
                arr[j], arr[j+1] = arr[j+1], arr[j]
    return arr

def get_input():
    arrays = []
    print("Введите массивы построчно (для завершения введите пустую строку):")
    while True:
        try:
            line = input()
            if line == "":
                break
            array = list(map(int, line.split()))
            arrays.append(array)
        except ValueError:
            print("Ошибка: некорректный ввод. Пожалуйста, введите числа через пробел.")
    return arrays

def read_test_cases(file_name):
    test_cases = []
    try:
        with open(file_name, 'r') as f:
            lines = f.readlines()
            for line in lines:
                input_str, expected_str = line.strip().split(';')
                input_array = list(map(int, input_str.split()))
                expected_array = list(map(int, expected_str.split()))
                test_cases.append((input_array, expected_array))
    except FileNotFoundError:
        print(f"Файл {file_name} не найден.")
    return test_cases

def run_tests(test_cases):
    passed = 0
    for i, (input_array, expected_array) in enumerate(test_cases):
        sorted_array = bubble_sort(input_array[:])  # Копируем массив перед сортировкой
        if sorted_array == expected_array:
            print(f"Тест {i + 1}: Результат да")
            passed += 1
        else:
            print(f"Тест {i + 1}: Результат нет")
            print(f"Ожидалось: {expected_array}, Получено: {sorted_array}")
    print(f"Пройдено тестов: {passed} из {len(test_cases)}")

if __name__ == "__main__":

    # Сортировка пользовательских массивов
    arrays = get_input()
    for array in arrays:
        print("Исходный массив:", array)
        print("Отсортированный массив:", bubble_sort(array))

    # Автоматическое тестирование
    test_cases_file = "D:/test_cases.txt"
    test_cases = read_test_cases(test_cases_file)
    if test_cases:
        print("\nЗапуск автоматических тестов:")
        run_tests(test_cases)
