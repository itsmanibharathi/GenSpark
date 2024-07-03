# modularization

# import the module named modul1
import modul1

# import the module named modul1 and rename it as m1
import modul1 as m1

# import the greeting function from the module named modul1

from modul1 import * # import all functions from the module named modul1, but this is not recommended
from modul1 import greeting # import the greeting function from the module named modul1

# import the greeting function from the module named modul1 and rename it as g
from modul1 import greeting as g

def main():
    modul1.greeting("Jonathan")
    m1.greeting("Jonathan")
    greeting("Jonathan")
    g("Jonathan")

if __name__ == "__main__":
    main()
