# 概要
ゲームエンジンUnituにより実装されたタンパク質ドッキングゲーム。タンパク質ドッキングとはタンパク質同士の
最適な結合を見つけるための手法であり,主に計算機による三次元空間の探索によって行われる。
このゲームではタンパク質ドッキングをゲームとして実装し,人間の直感をタンパク質ドッキングに利用することで
高精度かつ効率的なタンパク質ドッキングを行う。

# 必要な環境
ゲームエンジンUnityが必要。
バージョンは2017.4.17f1。その他のバージョンでの挙動は確認していない。

# 使い方
・フォルダidockをUnityで開いて実行

## 操作方法
・画面上のスライダー，ボタンは左クリック  
・側鎖の回転は、回転させたい側鎖が赤く光った状態のまま左クリックして回転  
・タンパク質自体の回転は回転させたいタンパク質を右ドラッグ  
・カメラの回転はタンパク質に被らない場所を左ドラッグ

# スクリプトについて
各機能を行っているスクリプトについて記す

## タンパク質の挙動
・タンパク質の回転はAssets/script/makebond/ProteinRotate.cs  
・タンパク質の移動はAssets/script/DisSlider/SpringMove.cs  
・側鎖の動きはAssets/script/makebond/CreateGenome/SideMove.cs

## タンパク質表面の表示
・タンパク質表面の表示はタンパク質ビューワーUnityMolを使用  
[UnityMol](https://www.bi.cs.titech.ac.jp/megadock/index_ja.html)  
・起動時の表面表示はAssets/script/makebond/Surface/SurfaceCreate.cs  
・側鎖移動時の表面更新はAssets/script/makebond/CreateGenome/PartRecreate.cs  

## スコア計算
・スコア計算はドッキングソフトMEGADOCKを利用して行っている  
[MEGADOCK4.0](https://www.bi.cs.titech.ac.jp/megadock/index_ja.html)  
・スコア計算はAssets/script/makebond/Score/ScoreCal.cs

# その他
## 実行時の注意(改善済み、下の変更履歴参照)
・一度実行した後,もう一度実行する場合,Assets/Resoures/PDB/1ppe内の1btpと1lu0フォルダを付属のものに更新する必要がある  
(側鎖を動かしていた場合表面の表示がおかしくなる)


# 変更履歴
## 0407
・スコア計算が正常に行われていなかったので行うように変更  
・実行時の注意にある実行のたびに行うフォルダの更新が不要になるように変更
