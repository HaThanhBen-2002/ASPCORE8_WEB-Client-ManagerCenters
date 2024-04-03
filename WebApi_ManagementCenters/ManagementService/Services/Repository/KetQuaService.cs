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
    public class KetQuaService: IKetQuaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public KetQuaService(IUnitOfWork unitOfWork, IMapper mapper)
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
                    return await _unitOfWork.KetQua.CheckId(id);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Create(KetQuaDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<KetQua>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.KetQua.Create(_mapper.Map<KetQua>(item));
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
                    return await _unitOfWork.KetQua.Delete(id, nguoiXoa, GetCurrentDateTime());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<KetQuaDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<KetQuaDto>>(await _unitOfWork.KetQua.GetAll());
            }
            catch
            {
                return new List<KetQuaDto>();
            }
        }

        public async Task<KetQuaDto> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return _mapper.Map<KetQuaDto>(await _unitOfWork.KetQua.GetById(id));
                }
                return new KetQuaDto();
            }
            catch
            {
                return new KetQuaDto();
            }
        }

        public object LoadingDataTableView(KetQuaDto item, int skip, int take)
        {
            try
            {
                if (item != null)
                {
                    return _unitOfWork.KetQua.LoadingDataTableView(_mapper.Map<KetQua>(item), skip, take);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<KetQuaDto>> Search(KetQuaDto item)
        {
            try
            {
                if (item != null)
                {
                    return _mapper.Map<List<KetQuaDto>>(await _unitOfWork.KetQua.Search(_mapper.Map<KetQua>(item)));
                }
                return new List<KetQuaDto>();
            }
            catch
            {
                return new List<KetQuaDto>();
            }
        }

        public async Task<int> SearchCount(KetQuaDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.KetQua.SearchCount(_mapper.Map<KetQua>(item));
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<object>> SearchName(KetQuaDto item)
        {
            try
            {
                if (item != null)
                {
                    return await _unitOfWork.KetQua.SearchName(_mapper.Map<KetQua>(item));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(KetQuaDto item)
        {
            try
            {
                if (item != null)
                {
                    // Chuyển đổi TrungTamDto thành TrungTam bằng AutoMapper
                    var trungTam = _mapper.Map<KetQua>(item);

                    // Kiểm tra hợp lệ của đối tượng TrungTam
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(trungTam, new ValidationContext(trungTam), validationResults, true);

                    if (!isValid)
                    {
                        // Nếu dữ liệu không hợp lệ, trả về false
                        return false;
                    }
                    return await _unitOfWork.KetQua.Update(_mapper.Map<KetQua>(item));
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
