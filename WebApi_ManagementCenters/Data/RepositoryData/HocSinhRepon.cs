using Data.InterfacesData;
using Data.Models;
using Data.Models.ModelView;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Data.RepositoryData
{
    public class HocSinhRepon: IHocSinh
    {
        private readonly ApplicationDbContext _context;
        public HocSinhRepon(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckId(int id)
        {
            return await _context.HocSinhs.AnyAsync(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaHocSinh == id);
        }

        public async Task<bool> Create(HocSinh item)
        {
            if (item != null)
            {
                item.MaHocSinh = null;
                await _context.HocSinhs.AddAsync(item);
            }
            return await Save();
        }

        public Task<bool> Delete(int id, string nguoiXoa, string ngayXoa)
        {
            var itemDelete = _context.HocSinhs.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaHocSinh == id).FirstOrDefault();
            if (itemDelete != null)
            {
                itemDelete.NguoiXoa = nguoiXoa;
                itemDelete.NgayXoa = ngayXoa;
                _context.HocSinhs.Update(itemDelete);
            }
            return Save();
        }

        public async Task<ICollection<HocSinh>> GetAll()
        {
            var allItem = await _context.HocSinhs.Where(c => c.NgayXoa == null && c.NguoiXoa == null).ToListAsync();
            return allItem;
        }

        public async Task<HocSinh> GetById(int id)
        {
            var item = await _context.HocSinhs.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaHocSinh == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return item;
            }
            return new HocSinh();
        }

        private Expression<Func<HocSinh, bool>> LambdaSearch(HocSinh item)
        {
            #region Create Lambda
            var parameterExpression = Expression.Parameter(typeof(HocSinh), "x");
            var expressions = new List<Expression>();
            // Thêm điều kiện tìm kiếm GẦN ĐÚNG STRING
            if (!string.IsNullOrEmpty(item.TenHocSinh))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.TenHocSinh)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenHocSinh)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.ThongTin))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.ThongTin)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.ThongTin)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgaySinh))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.NgaySinh)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgaySinh)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.GioiTinh))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.GioiTinh)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.GioiTinh)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.DiaChi))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.DiaChi)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.DiaChi)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.ChieuCao))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.ChieuCao)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.ChieuCao)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.CanNang))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.CanNang)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.CanNang)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TinhTrangRang))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.TinhTrangRang)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TinhTrangRang)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TinhTrangMat))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.TinhTrangMat)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TinhTrangMat)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Bmi))
            {
                // Tạo biểu thức so sánh cho ScoreName
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.Bmi)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Bmi)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TinhTrangTamLy))
            {
                // Tạo biểu thức so sánh cho ScoreName
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.TinhTrangTamLy)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TinhTrangTamLy)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.ChucNangCoThe))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.ChucNangCoThe)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.ChucNangCoThe)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.DanhGiaSucKhoe))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.DanhGiaSucKhoe)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.DanhGiaSucKhoe)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Cccdcha))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.Cccdcha)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Cccdcha)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.Cccdme))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.Cccdme)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.Cccdme)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TenCha))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.TenCha)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenCha)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.TenMe))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.TenMe)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.TenMe)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgaySinhCha))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.NgaySinhCha)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgaySinhCha)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgaySinhMe))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.NgaySinhMe)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgaySinhMe)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.SoDienThoaiCha))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.SoDienThoaiCha)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.SoDienThoaiCha)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.SoDienThoaiMe))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.SoDienThoaiMe)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.SoDienThoaiMe)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.EmailCha))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.EmailCha)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.EmailCha)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.EmailMe))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.EmailMe)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.EmailMe)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgheNghiepCha))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.NgheNghiepCha)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgheNghiepCha)
                );
                expressions.Add(expression);
            }
            if (!string.IsNullOrEmpty(item.NgheNghiepMe))
            {
                var expression = Expression.Call(
                    Expression.Property(parameterExpression, nameof(HocSinh.NgheNghiepMe)),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Expression.Constant(item.NgheNghiepMe)
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện tìm kiếm INT
            if (item.MaHocSinh.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(HocSinh.MaHocSinh)),
                    Expression.Constant(item.MaHocSinh, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaLop.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(HocSinh.MaLop)),
                    Expression.Constant(item.MaLop, typeof(int?))
                );
                expressions.Add(expression);
            }
            if (item.MaTrungTam.HasValue)
            {
                var expression = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(HocSinh.MaTrungTam)),
                    Expression.Constant(item.MaTrungTam, typeof(int?))
                );
                expressions.Add(expression);
            }
            // Thêm điều kiện Check Ngày Xóa, Người Xóa
            var expressionNgayXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(HocSinh.NgayXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNgayXoaIsNull);

            var expressionNguoiXoaIsNull = Expression.Equal(Expression.Property(parameterExpression, nameof(HocSinh.NguoiXoa)), Expression.Constant(null, typeof(string)));
            expressions.Add(expressionNguoiXoaIsNull);

            var combinedExpression = expressions.Any() ? expressions.Aggregate(Expression.AndAlso) : Expression.Constant(true);
            var lambda = Expression.Lambda<Func<HocSinh, bool>>(combinedExpression, parameterExpression);
            #endregion
            return lambda;
        }


        public object LoadingDataTableView(HocSinh item, int skip, int take)
        {

            var lambda = LambdaSearch(item);
            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = _context.HocSinhs.Where(lambda).OrderByDescending(n => n.MaHocSinh).Skip(skip).Take(take).Select( x => new
            {
                x.MaHocSinh,
                x.TenHocSinh,
                x.NgaySinh,
                x.GioiTinh,
                TenLop = x.MaLop != null ? _context.Lops.Where(l => l.MaLop == x.MaLop).Select(l => l.TenLop).FirstOrDefault() : null
            }).ToList();
            int recordsTotal = _context.HocSinhs.Where(lambda).Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
            return jsonData;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<ICollection<HocSinh>> Search(HocSinh item)
        {
            var lambda = LambdaSearch(item);

            var filteredResults = await _context.HocSinhs.Where(lambda).ToListAsync();
            foreach (var result in filteredResults)
            {
                result.HinhAnh = null;
            }
            return filteredResults;
        }

        public Task<bool> Update(HocSinh item)
        {
            if (item != null)
            {
                _context.HocSinhs.Update(item);
            }
            return Save();
        }



        public async Task<HocSinhView> GetHocSinhView(int id)
        {
            var item = await _context.HocSinhs.Where(c => c.NgayXoa == null && c.NguoiXoa == null && c.MaHocSinh == id).FirstOrDefaultAsync();
            if (item != null)
            {
                HocSinhView itemView = new HocSinhView();
                itemView.MaHocSinh = item.MaHocSinh;
                itemView.TenHocSinh = item.TenHocSinh;
                itemView.NgaySinh = item.NgaySinh;
                itemView.GioiTinh = item.GioiTinh;
                itemView.MaLop = item.MaLop;
                itemView.MaTrungTam = item.MaTrungTam;
                return itemView;
            }
            return new HocSinhView();
        }

        public async Task<List<object>> SearchName(HocSinh item)
        {
            var lambda = LambdaSearch(item);

            // Sử dụng biểu thức lambda để lọc dữ liệu từ DbContext và ánh xạ kết quả vào AcademicScore
            var data = await _context.HocSinhs.Where(lambda).OrderByDescending(n => n.MaHocSinh).Select(x => new {
                MaHocSinh = x.MaHocSinh,
                TenHocSinh = x.TenHocSinh,
                EmailCha = x.EmailCha,
                EmailMe = x.EmailMe
            }).ToListAsync();

            return data.Select(x => new {
                maHocSinh = x.MaHocSinh,
                tenHocSinh = x.TenHocSinh,
                emailCha = x.EmailCha,
                emailMe = x.EmailMe
            }).ToList<object>();
        }

        public async Task<int> SearchCount(HocSinh item)
        {
            var lambda = LambdaSearch(item);
            return _context.HocSinhs.Where(lambda).Count();
        }
    }
}
