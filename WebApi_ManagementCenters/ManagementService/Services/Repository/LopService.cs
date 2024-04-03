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
    public class LopService: ILopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LopService(IUnitOfWork unitOfWork, IMapper mapper)
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
                    return await _unitOfWork.Lop.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(LopDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<Lop>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.Lop.Create(_mapper.Map<Lop>(item));
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
                    return await _unitOfWork.Lop.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<LopDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<LopDto>>(await _unitOfWork.Lop.GetAll());
            }
            catch
            {
                return new List<LopDto>();
            }
        }

        public async Task<LopDto> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<LopDto>(await _unitOfWork.Lop.GetById(id));
                }
                return new LopDto();
            }
            catch
            {
                return new LopDto();
            }
        }

        public object LoadingDataTableView(LopDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    return _unitOfWork.Lop.LoadingDataTableView(_mapper.Map<Lop>(item), skip, take);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<LopDto>> Search(LopDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<LopDto>>(await _unitOfWork.Lop.Search(_mapper.Map<Lop>(item)));
                }
                return new List<LopDto>();
            }
            catch
            {
                return new List<LopDto>();
            }
        }

        public async Task<int> SearchCount(LopDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.Lop.SearchCount(_mapper.Map<Lop>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<object>> SearchName(LopDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.Lop.SearchName(_mapper.Map<Lop>(item));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(LopDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<Lop>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.Lop.Update(_mapper.Map<Lop>(item));
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
