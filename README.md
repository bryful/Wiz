﻿# WizardryFCEdit
ファミコン版ウイザードリィのステートファイルエディタです。

キャラクタ作成時に高ボーナスを狙うのに疲れたので作りました。

![ss](https://user-images.githubusercontent.com/50650451/69474518-7ba11100-0e05-11ea-9a2c-36fc11fffc6a.png)


好きなキャラクタを作るために作ったので、Level99の強いキャラとかにするとゲームがつまらなくなりますので注意です。

# 出来る事
ファミコン版ウィザードリィのシナリオ１と２と３に対応しています。

基本的にキャラのアライメント（善悪中立）、職業(CLass)、種族(Race)、年齢のパラメータの変更、「くんれんじょ」のキャラ順番の変更（使用時は注意）です。

一応その他のものも変更可能ですが、ゲームがつまらなくなるので使わないのが最良です。
経験値/ゴールド/じょうたい/アイテムはこのゲームの目標になるので変更不可です。

キャラクタの作成はできません。

一応Savファイルも読めますが、保存はシナリオ1だけです。それもバグがあるかもです

# 使い方
WindowsのnnnesterJエミュレータかAndroidのJohn nessのStateファイルにのみ対応しています。必ず、設定でzip圧縮なしにしてください。

ステートファイルを読み込むとシナリオを自動判別します。

左のリストでキャラクタの選択。
キャラクタのパラメータをクリックすれば、変更できる時はリストが表示されるので選択できます。数値パラメータは矢印が出ますのでそこをクリックです。

基本的に「くんれんじょ」で迷宮にキャラがいない状態のステートファイルで編集を行ってください。それ以外の状態だとバグります。キャラクタが迷宮のどこかに行ったり、存在しないキャラクタが見えたりします。

# キャラアイコン
デフォルトではキャラの職業(CLASS)でそれに合ったアイコンが表示されるようになっていますが、キャラクタと同じ名前の画像を当てはめることができます。

Editメニューの「キャラクタアイコンのフォルダを指定」で適当なフォルダを選びキャラクタと同じ名前の画像を置けば起動時に読み込みます。

画像はpngかjpgで画像サイズは100pixelx100pixelです。
サイズは適当にリサイズして表示されます

例えばキャラ名が「サヒ゛エル」の場合は「サヒ゛エル.png」とかです。
「゛」とか「゜」は別文字扱いなので注意してください。基本的に全角のみです。
「゛」とか「゜」はここのテキストからコピー＆ペーストするのが確実です。

# 解析
キャラデータの解析は「Welcome to Wizardry Institute of Analysis」の情報を使わせてもらいました。ただ現在は閉鎖されています。
今回、過去にDelphiで作成したものソースから情報を獲得しています。

sampleフォルダにdelphiのソースを入れておきました。


# Stateファイル
Jone nesとnnnesterJに対応していますが、その他のエミュレータは独自の圧縮かかっていたので解析していません。
バイナリ中のSRAMという文字列の後にSRAMデータが入っています。

# Saveファイルのチェックサム。
シナリオ1のセーブデータキャラクタのチェックサムを解析しました。  
キャラデータサイズは0x100byteで0x70から0xE個に先頭から8Byteごとのチェックサムが、0x7E,0x7Fに0x00-0x7Dまでのチェックサムが入ります。  

0x80以降は0x00-0x7Fの値を0xFFとxorして上位bitと下位bitを入れ替えた値が逆順に収納されています。

0x70に入るチェックサムは基本的に加算式  
0x00-0x07を対象に まず0x08を初期値で加算、加算後0xFFを超えたときは適当に丸め込みします。
  
 //v は加算後の結果 unsigned short  
 if( (v>>8) != 0) {  
     v = (v && 0xFF) + 0x1; //単純に１を足す  
 }  

0x70-0x7Dに上記のように8Byteごと(0x00-0x7Dを8分割した)のチェックサムの値が入ります。

0x70以降のチェックサム計算が終わった後、0x7E,0x7Fに 0x00-0x7DのCRC-8-CCITTで初期値0xFFFFの値が入ります。

シナリオ２と３は解析してません。  
というかよくわからないです。  

# Dependency
Visual studio 2017 C#


# License

This software is released under the MIT License, see LICENSE

# Authors

bry-ful(Hiroshi Furuhashi) http://bryful.yuzu.bz/  
twitter:[bryful](https://twitter.com/bryful)  
bryful@gmail.com  

最新ソースはここに
https://github.com/bryful  

# References

Wizardry(NES) 解析 https://taotao54321.github.io/appsouko/work/Game/Wiz1_NES/  
Wizardry1/Apple/解析メモ https://wiliki.zukeran.org/index.cgi?Wizardry1%2FApple%2F%B2%F2%C0%CF%A5%E1%A5%E2  
Welcome to Wizardry Institute of Analysis(閉鎖) http://marin69.hp.infoseek.co.jp  
