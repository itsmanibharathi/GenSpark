with open("day58_py_Day3/learning/data.txt", "a") as file:
    print("Hello, World!", file=file)



# Left align
print(f"{'Left aligned':<20}")

# Right align
print(f"{'Right aligned':>20}")

# Center align
print(f"{'Center aligned':^20}")


# Pad with spaces (default)
print(f"{'Padded':<10}")

# Pad with zeros
print(f"{'Padded':0>10}")

# Pad with asterisks
print(f"{'Padded':*^10}")

pi = 3.141592653589793
print(f"Pi to 2 decimal places: {pi:.2f}")


large_number = 1000000
print(f"Large number with separator: {large_number:,}")

import textwrap

paragraph = "This is a long paragraph that needs to be wrapped properly to fit within a specific width for better readability."
print(textwrap.fill(paragraph, width=50))


data = [
    ("Alice", 30, 12345.678),
    ("Bob", 25, 98765.432),
    ("Charlie", 35, 56789.123)
]

header = f"{'Name':<10} {'Age':<10} {'Balance':<15}"
"""
Name       Age        Balance
==============================
"""
print(header)
print("=" * len(header))

for name, age, balance in data:
    print(f"{name:<10} {age:<10} ${balance:<15,.2f}")