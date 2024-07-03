# python documentation

# python documentation is a way to document your code. 
# It is a good practice to document your code so that other developers can understand your code. 
# You can use the following ways to document your code:
#
# 1. docstrings
# 2. comments
# 3. type hints and annotations


# 1. docstrings

# Docstrings are used to document your code.
# They are written within triple quotes.
# You can write docstrings for modules, classes, functions, and methods.
# You can access docstrings using the __doc__ attribute.
# You can write multi-line docstrings using triple quotes.

# Example:
def add(a, b):
    """
    This function takes two arguments and returns their sum.
    """
    return a + b

print(add.__doc__)


# 2. comments

# Comments are used to explain your code.
# They are written after the # symbol.
# You can write single-line comments using the # symbol.
# You can write multi-line comments using triple quotes.

# Example:
# This is a single-line comment
"""
This is a multi-line comment
"""


# 3. type hints and annotations
# Type hints are used to specify the type of a variable.
# They are written after the variable name and a colon.
# You can use the following types: int, float, str, bool, list, tuple, dict, set, etc.
# You can use the typing module to specify complex types.

# Example:
def add(a: int, b: int) -> int:
    """
    This function takes two integers and returns their sum.
    """
    return a + b

print(add(1, 2))