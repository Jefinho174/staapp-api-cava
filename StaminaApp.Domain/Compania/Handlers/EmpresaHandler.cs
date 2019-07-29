using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flunt.Notifications;
using MediatR;
using StaminaApp.Core.Commands;
using StaminaApp.Core.Handler;
using StaminaApp.Domain.Compania.Commands;
using StaminaApp.Domain.Compania.Entidades;
using StaminaApp.Domain.Enum;
using StaminaApp.Domain.ObjetoValores;
using StaminaApp.Domain.Repositorios;

namespace StaminaApp.Domain.Compania.Handlers
{
    public class EmpresaHandler :
        Notifiable,
        IRequestHandler<CadastrarEmpresaCommand,ICommandResult>,
        IRequestHandler<EditarEmpresaCommand,ICommandResult>,
        IRequestHandler<DeletarEmpresaCommand,ICommandResult>,
        IRequestHandler<CadastrarCentroCustoCommand, ICommandResult>,
        IRequestHandler<EditarCentroCustoCommand, ICommandResult>
    {

        private readonly IEmpresaRepositorio _repositorio;

        public EmpresaHandler(IEmpresaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<ICommandResult> Handle(CadastrarEmpresaCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request);
                return Task.FromResult<ICommandResult>(new CommandResult("001", false, "Não foi possível realizar cadastro da empresa"));
            }

            Documento cnpj = new Documento(request.Cnpj, ETipoDocumento.CNPJ);
            Documento inscricaoEstadual = new Documento(request.InscricaoEstadual, ETipoDocumento.INSCRICAO_ESTADUAL);
            Documento inscricaoMunicipal = new Documento(request.InscricaoMunicipal, ETipoDocumento.INSCRICAO_MUNICIPAL);
            Endereco endereco = new Endereco(request.Rua, request.Numero, request.Bairro, request.Cidade, request.Estato, request.Pais, request.CodigoPostal, request.Complemento);
            Empresa empresa = new Empresa(request.RazaoSocial, cnpj, inscricaoEstadual, inscricaoMunicipal, endereco);

            AddNotifications(cnpj, inscricaoEstadual, inscricaoMunicipal, endereco, empresa);
            if (Valid)
            {
                if (!_repositorio.ExisteCnpj(ref empresa))
                {
                    empresa = _repositorio.InsertEmpresa(empresa);
                    return Task.FromResult<ICommandResult>(new CommandResult("000", true, "Empresa cadastrada com sucesso"));
                }
            }
            return Task.FromResult<ICommandResult>(new CommandResult("001", false, "Não foi possível realizar cadastro da empresa"));
        }

        public Task<ICommandResult> Handle(EditarEmpresaCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request);
                return Task.FromResult<ICommandResult>( new CommandResult("001", false, "Não foi possível editar dados da empresa"));
            }

            Documento cnpj = new Documento(request.Cnpj, ETipoDocumento.CNPJ);
            Documento inscricaoEstadual = new Documento(request.InscricaoEstadual, ETipoDocumento.INSCRICAO_ESTADUAL);
            Documento inscricaoMunicipal = new Documento(request.InscricaoMunicipal, ETipoDocumento.INSCRICAO_MUNICIPAL);
            Endereco endereco = new Endereco(request.Rua, request.Numero, request.Bairro, request.Cidade, request.Estato, request.Pais, request.CodigoPostal, request.Complemento);
            Empresa empresa = new Empresa(request.RazaoSocial, cnpj, inscricaoEstadual, inscricaoMunicipal, endereco);
            empresa.Id = request.Id;
            AddNotifications(cnpj, inscricaoEstadual, inscricaoMunicipal, endereco, empresa);
            if (Valid)
            {
                if (!_repositorio.ExisteCnpj(ref empresa))
                {
                    empresa = _repositorio.UpdateEmpresa(empresa);
                    return Task.FromResult<ICommandResult>(new CommandResult("000", true, "Empresa editada com sucesso"));
                }
                else
                {
                    AddNotification("Cnpj", "Cnpj já foi cadastrado");
                }
            }
            return Task.FromResult<ICommandResult>( new CommandResult("001", false, "Não foi possível realizar editar da empresa"));
        }

        public Task<ICommandResult> Handle(DeletarEmpresaCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request);
                return Task.FromResult<ICommandResult>( new CommandResult("001", false, "Não foi possível realizar cadastro da empresa"));
            }

            var empresa = _repositorio.FindEmpresa(request.Id);
            if (empresa == null)
            {
                AddNotification("", "Empresa não foi encontrada");
                return Task.FromResult<ICommandResult>(new CommandResult("001", false, "Não foi possível realizar cadastro centro de custo"));
            }

            if (Valid)
            {
                _repositorio.DeleteEmpresa(empresa.Id);
                Task.FromResult<ICommandResult>(new CommandResult("000", true, "Empresa cadastrada com sucesso"));
            }
            return Task.FromResult<ICommandResult>(new CommandResult("001", false, "Não foi possível realizar cadastro da empresa"));
        }

        public Task<ICommandResult> Handle(CadastrarCentroCustoCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
            {
                AddNotifications(request);
                return Task.FromResult<ICommandResult>(new CommandResult("001", false, "Não foi possível realizar cadastro centro de custo"));
            }

            var empresa = _repositorio.FindEmpresa(request.IdEmpresa);
            if (empresa == null)
            {
                AddNotification("", "Empresa não foi encontrada");
                return Task.FromResult<ICommandResult>(new CommandResult("001", false, "Não foi possível realizar cadastro centro de custo"));
            }
            
            CentroCusto controCusto = new CentroCusto(request.CodigoControCusto, request.Descricao);

            if (controCusto.Valid)
            {
                empresa.AddCentroCusto(controCusto);
            }
            else
            {
                AddNotifications(controCusto);
            }

            var centroCustoExistentes = _repositorio.ExisteCodigoCentroCusto(ref empresa);
            if (centroCustoExistentes.Any())
            {
                foreach (var c in centroCustoExistentes)
                {
                    empresa.RemoverCentroCusto(c);
                }
            }

            if (empresa.CentrosCusto.Where(x => x.Id.Equals(0)).Count() > 0)
            {
                if (_repositorio.InserirCentroCusto(ref empresa))
                {
                    return Task.FromResult<ICommandResult>(new CommandResult("000", true, "Dados inseridos com sucesso"));
                }
            }
            else
            {
                AddNotification("", "Nenhum centro de custo valído para gravar");
            }
            return Task.FromResult<ICommandResult>(new CommandResult("001", false, "Não foi possível realizar cadastro centro de custo"));
        }

        public Task<ICommandResult> Handle(EditarCentroCustoCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if(request.Invalid){
                AddNotifications(request);
                return Task.FromResult<ICommandResult>( new CommandResult("001", false, "Não foi possível editar centro de custo"));
            }

            CentroCusto centroCusto = _repositorio.FindCentroCusto(request.IdControCusto);
            if(centroCusto == null){
                AddNotification("","Centro de custo não exite");
                return Task.FromResult<ICommandResult>( new CommandResult("001", false, "Não foi possível editar centro de custo"));
            }

            


            throw new System.NotImplementedException();
        }
    }
}