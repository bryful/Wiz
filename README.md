# WizardryFCEdit
ファミコン版ウイザードリィのステートファイルエディタです。
WindowsのnnnesterJエミュレータかAndroidのJohn nessのStateファイルにのみ対応しています。

キャラクタ作成時に高ボーナスを狙うのに疲れたので作りました。
好きなキャラクタを作るために作ったので、Level99の強いキャラとかにするとゲームがつまらなくなりますので注意です。

基本的に「くんれんじょ」で迷宮にキャラがいない状態のステートファイルで編集を行ってください。
それ以外の状態だとバグります。キャラクタが迷宮のどこかに行ったり、存在しないキャラクタが見えたりします。

☆できること
基本的にキャラのアライメント（善悪中立）職業(CLass)種族(Race)年齢のパラメータの変更
「くんれんじょ」のキャラ順番の変更（使用時は注意）です。

一応その他のものも変更可能ですが、ゲームがつまらなくなるので使わないのが最良です。
経験値/ゴールド/じょうたい/アイテムはこのゲームの目標になるので変更不可です。


キャラクタの作成はできません。

☆キャラアイコン
デフォルトではキャラの職業(CLASS)でそれに合ったアイコンが表示されるようになっていますが、
キャラクタと同じ名前の画像を当てはめることができます。

Editメニューの「キャラクタアイコンのフォルダを指定」で適当なフォルダを選びキャラクタと同じ名前の画像を置けば
起動時に読み込みます。

画像はpngかjpgで画像サイズは100pixelx100pixelです。
サイズは適当にリサイズして表示されます

例えばキャラ名が「サヒ゛エル」の場合は「サヒ゛エル.png」とかです。
「゛」とか「゜」は別文字扱いなので注意してください。基本的に全角のみです。



# Dependency
Visual studio 2017 C#


# License

This software is released under the MIT License, see LICENSE

# Authors

bry-ful(Hiroshi Furuhashi) http://bryful.yuzu.bz/  
twitter:[bryful](https://twitter.com/bryful)  
bryful@gmail.com  

# References
Wizardry(NES) 解析 https://taotao54321.github.io/appsouko/work/Game/Wiz1_NES/
Wizardry1/Apple/解析メモ https://wiliki.zukeran.org/index.cgi?Wizardry1%2FApple%2F%B2%F2%C0%CF%A5%E1%A5%E2
