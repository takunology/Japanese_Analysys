import sys
import MeCab
import pandas as pd
import random

test_file = open("example.txt", "r")

df = pd.read_csv("Nounplace.csv", usecols=[0], engine='python', names="", dtype="")

m = MeCab.Tagger("")

for line in test_file:
    text = m.parse(line)

#priint(text)
test_file.close()
print(line)

num = random.randint(1, 10000)

print(">", end="")
print("私は" + df.iloc[num] + "に住んでいます")

