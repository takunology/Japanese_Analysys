import MeCab
import sys
import re
from collections import Counter

#ファイル指定
File = 'Test\\example.txt'
with open(File ,encoding="utf-8") as f:
    data = f.read()

parse = MeCab.Tagger().parse(data)
lines = parse.split('\n')
items = (re.split('[\t,]', line) for line in lines)

#結果の表示
for item in items:
    print(item)