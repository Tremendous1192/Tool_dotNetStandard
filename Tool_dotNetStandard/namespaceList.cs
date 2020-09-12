using System;



namespace Tremendous1192
{

    //*
    //Tremendous1192 : 作者名
    //**
    //Tremendous1192.Tool_dotNetStandard : 製品名

    //***
    //Tremendous1192.Tool_dotNetStandard.DataProcessing : 技術名(大枠) ; 

    //****
    //Tremendous1192.Tool_dotNetStandard.DataProcessing.Base: 技術名(中枠) ; 基本的な処理のクラス 
    //◆DesignMatrix class : 計画行列のクラス (標本平均、標本分散・共分散行列を計算する , 引用されやすいのでBaseに変更)
    //◆IAction class : 作用関数 (正の数)
    //◆IKernel class : カーネル関数のインターフェース
    //◆IRandomNumber class : 乱数生成のインターフェース
    //◆IScalarFunction class: スカラー値関数のインターフェース
    //◆IVectorFunction class: ベクトル値関数のインターフェース
    //◆Matrix class : 行列計算
    //TaylorSeriesDeciml class : Decimal型のテーラー展開のクラス(doubke型で、モンテカルロ法の精度を出せるので、カット)
    //◆TypeChange class : 型変換を行う

    //****
    //Tremendous1192.Tool_dotNetStandard.DataProcessing.IO : 技術名(中枠) ; 入出力を行う
    //◆Directory class : ディレクトリに関する処理を行う。IOにあった方が自然。
    //◆Text class : テキストの入出力を行う


    //****
    //Tremendous1192.Tool_dotNetStandard.DataProcessing.MachineLerning : 技術名(中枠) ; 機械学習の解析を行う。
    //MonteCarlo class : モンテカルロ法のクラス , doubleで十分

    //*****
    //Tremendous1192.Tool_dotNetStandard.DataProcessing.MachineLerning.NeuralNetWork : 技術名(小枠) ; ニューラルネットワークを扱う
    //継承を利用したほうが合理的
    //BaseLayer : 基底クラス
    //HiddenLayer class : 隠れ層のクラス
    //RegressionLayer class : 回帰のクラス
    //MulticlassClassificationLayer : 分類のクラス

    //*****
    //Tremendous1192.Tool_dotNetStandard.DataProcessing.MachineLerning.SupportVector : 技術名(小枠) ; サポートベクトルを扱う
    //◆SupportVectorMachine class : サポートベクトルマシンのクラス


    //****
    //Tremendous1192.Tool_dotNetStandard.DataProcessing.Statistics : 技術名(中枠) ; 統計的解析を行う。
    //InferentialStatistics class : 推測統計的処理のクラス(不偏平均 , 不偏分散を計算する)

    //*****
    //Tremendous1192.Tool_dotNetStandard.DataProcessing.Statistics.GeneralizedLinearModel : 技術名(小枠) ; 一般化線形モデル。
    //LinerRegression class : 線形回帰用のクラス

}



