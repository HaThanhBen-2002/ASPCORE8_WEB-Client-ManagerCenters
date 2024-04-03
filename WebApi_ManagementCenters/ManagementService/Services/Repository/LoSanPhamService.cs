using AutoMapper;
using Data.Dtos;
using Data.InterfacesData;
using Data.Models;
using ManagementService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManagementService.Support.Support;
namespace ManagementService.Services.Repository
{
    public class LoSanPhamService: ILoSanPhamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LoSanPhamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CheckId(int id)
        {
            try
            {
                if (id != 0)
                {
                    return await _unitOfWork.LoSanPham.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(LoSanPhamDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<LoSanPham>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.LoSanPham.Create(_mapper.Map<LoSanPham>(item));
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id, string nguoiXoa)
        {
            try
            {
                if (id != 0 && nguoiXoa != null)
                {
                    return await _unitOfWork.LoSanPham.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<LoSanPhamDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<LoSanPhamDto>>(await _unitOfWork.LoSanPham.GetAll());
            }
            catch
            {
                return new List<LoSanPhamDto>();
            }
        }

        public async Task<LoSanPhamDto> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<LoSanPhamDto>(await _unitOfWork.LoSanPham.GetById(id));
                }
                return new LoSanPhamDto();
            }
            catch
            {
                return new LoSanPhamDto();
            }
        }

        public object LoadingDataTableView(LoSanPhamDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    return _unitOfWork.LoSanPham.LoadingDataTableView(_mapper.Map<LoSanPham>(item), skip, take);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<LoSanPhamDto>> Search(LoSanPhamDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<LoSanPhamDto>>(await _unitOfWork.LoSanPham.Search(_mapper.Map<LoSanPham>(item)));
                }
                return new List<LoSanPhamDto>();
            }
            catch
            {
                return new List<LoSanPhamDto>();
            }
        }

        public async Task<int> SearchCount(LoSanPhamDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.LoSanPham.SearchCount(_mapper.Map<LoSanPham>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<object>> SearchName(LoSanPhamDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.LoSanPham.SearchName(_mapper.Map<LoSanPham>(item));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(LoSanPhamDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<LoSanPham>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.LoSanPham.Update(_mapper.Map<LoSanPham>(item));
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
