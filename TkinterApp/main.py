import sys
import tkinter as View
from tkinter import messagebox as MessageBox 
from tkinter import font

# Tkinter クラスのインスタンス化
MainWindow = View.Tk()

# ウィンドウのタイトル
MainWindow.title("ほげほげ")
# ウィンドウサイズの指定
MainWindow.geometry("700x400")
# ウィンドウの最小サイズの指定
MainWindow.minsize(100,100)
# ウィンドウの最大サイズの指定
MainWindow.maxsize(1000,1000)
# ウィンドウのサイズを固定するか（0 固定, 1 可変）
MainWindow.resizable(1,1)

# ラベルの作成
Label1 = View.Label(MainWindow, text="好きな文字を入力してくださいな")
# ラベル内のフォント指定
font1 = font.Font(family="Helvetica", size=20, weight="bold")
# ラベルの座標指定
#Label1.place(x=50, y=10)
Label1.pack()

# 進捗度を表示するステータスバー
Statusbar = View.Label(MainWindow, text="ステータスが表示されます", borderwidth=2, relief="groove")
# バーの表示する位置、fill で X軸いっぱいに広げて表示
Statusbar.pack(side=View.BOTTOM, fill=View.X)

# ボタンを使う
def On_Click():
    # ボタンのクリックイベントハンドラ
    text = Textbox1.get()
    MessageBox.showinfo("ボタンクリック", text)
    Statusbar.update
# ボタンの引数に command を指定してトリガを設定する
Button1 = View.Button(MainWindow, text="クリック", command=On_Click)
Button1.place(x=400, y=100)

# テキストボックス
Textbox1 = View.Entry(width=30)
Textbox1.place(x=200, y=100)

# ウィンドウ GUI を動かすための処理
MainWindow.mainloop()