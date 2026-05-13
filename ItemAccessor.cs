using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS_DB_Sample.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Accessor;
using CS_DB_Exercise.Infrastructures.Contexts;

namespace CS_DB_Sample.Infrastructures.Queries;
/// <summary>
/// itemテーブルにアクセスするクラス
/// </summary>
/// <author>Fullness,Inc.</author>
/// <date>2025-11-16</date>
/// <version>1.0.0</version>
public class ItemAccessor
{
    private readonly AppDbContext _context;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    public ItemAccessor(AppDbContext context)
    {
        _context = context;
    }
    /// <summary>
    /// 商品を登録する
    /// </summary>
    /// <param name="item">登録データを保持するEntity</param>
    /// <returns></returns>
    public ItemEntity Create(ItemEntity item)
    {
        // 新規商品を追加する
        var result = _context.Add(item);
        // 変更を永続化する
        _context.SaveChanges();
        return result.Entity;
    }

    /// <summary>
    /// 複数の商品を登録する
    /// </summary>
    /// <param name="items">登録データを保持するEntityのリスト</param>
    public void CreateRange(List<ItemEntity> items)
    {
        // 新規商品を追加する
        _context.AddRange(items);
        // 変更を永続化する
        _context.SaveChanges();
    }
}