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
    public class SuDungDichVuService: ISuDungDichVuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SuDungDichVuService(IUnitOfWork unitOfWork, IMapper mapper)
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
                    return await _unitOfWork.SuDungDichVu.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(SuDungDichVuDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<SuDungDichVu>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.SuDungDichVu.Create(_mapper.Map<SuDungDichVu>(item));
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
                    return await _unitOfWork.SuDungDichVu.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<SuDungDichVuDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<SuDungDichVuDto>>(await _unitOfWork.SuDungDichVu.GetAll());
            }
            catch
            {
                return new List<SuDungDichVuDto>();
            }
        }

        public async Task<SuDungDichVuDto> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<SuDungDichVuDto>(await _unitOfWork.SuDungDichVu.GetById(id));
                }
                return new SuDungDichVuDto();
            }
            catch
            {
                return new SuDungDichVuDto();
            }
        }

        public object LoadingDataTableView(SuDungDichVuDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    return _unitOfWork.SuDungDichVu.LoadingDataTableView(_mapper.Map<SuDungDichVu>(item), skip, take);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<SuDungDichVuDto>> Search(SuDungDichVuDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<SuDungDichVuDto>>(await _unitOfWork.SuDungDichVu.Search(_mapper.Map<SuDungDichVu>(item)));
                }
                return new List<SuDungDichVuDto>();
            }
            catch
            {
                return new List<SuDungDichVuDto>();
            }
        }

        public async Task<int> SearchCount(SuDungDichVuDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.SuDungDichVu.SearchCount(_mapper.Map<SuDungDichVu>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<object>> SearchName(SuDungDichVuDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.SuDungDichVu.SearchName(_mapper.Map<SuDungDichVu>(item));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(SuDungDichVuDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<SuDungDichVu>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.SuDungDichVu.Update(_mapper.Map<SuDungDichVu>(item));
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
