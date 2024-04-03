using Data.InterfacesData;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Data.RepositoryData
{
    public class ChiTietThuChiRepon : IChiTietThuChi
    {
        private readonly ApplicationDbContext _context;
        public ChiTietThuChiRepon(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckId(int id)
        {
            return await _context.ChiTietThuChis.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaChiTiet == id);
        }

        public async Task<bool> Create(ChiTietThuChi item)
        {
            if (item != null)
            {
                item.MaChiTiet = null;
                await _context.ChiTietThuChis.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa,string ngayXoa)
        {
            var itemDelete = _context.ChiTietThuChis.Where(c=> c.NgayXoa == null && c.NguoiXoa ==null && c.MaChiTiet == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.ChiTietThuChis.Update(itemDelete);
            }
            return Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
        private Expression<Func<ChiTietThuChi, bool>> LambdaSearch(ChiTietThuChi item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(ChiTietThuChi), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenChiTiet))
            {
                // Tạo biểu thức so sánh cho ScoreName
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(ChiTietThuChi.TenChiTiet)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenChiTiet)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.DonVi))
            {
                // Tạo biểu thức so sánh cho ScoreName
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(ChiTietThuChi.DonVi)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.DonVi)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.SoLuong))
            {
                // Tạo biểu thức so sánh cho ScoreName
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(ChiTietThuChi.SoLuong)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.SoLuong)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TongTien))
            {
                // Tạo biểu thức so sánh cho ScoreName
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(ChiTietThuChi.TongTien)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TongTien)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaChiTiet.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(ChiTietThuChi.MaChiTiet)),
                    Expression.Constant(item.MaChiTiet, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaPhieu.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(ChiTietThuChi.MaPhieu)),
                    Expression.Constant(item.MaPhieu, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(ChiTietThuChi.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(ChiTietThuChi.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<ChiTietThuChi, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }
        public async Task<ICollection<ChiTietThuChi>> Search(ChiTietThuChi item)
        {

            var lambda = LambdaSearch(item);
            var filteredResults = await _context.ChiTietThuChis.Where(lambda).ToListAsync();
            return filteredResults;
        }

        public Task<bool> Update(ChiTietThuChi item)
        {
            if (item != null)
            {
                _context.ChiTietThuChis.Update(item);
            }
            return Save();
        }

        public async Task<ICollection<ChiTietThuChi>> SearchByPhieuThuChiId(int id)
        {
            var filteredResults = await _context.ChiTietThuChis.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaPhieu == id).ToListAsync();
            return filteredResults;
        }
    }
}
