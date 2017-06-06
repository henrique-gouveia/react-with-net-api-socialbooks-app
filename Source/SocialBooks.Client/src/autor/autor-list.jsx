import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import Content from '../template/content'

import { listar, excluir, modificar, novo } from './autor-actions'

class AutorList extends Component {

    componentWillMount() {
        this.props.listar()
    }

    renderRows() {
        const list = this.props.list || []
        
        if (list.length === 0) {
            return  (
                <tr key='0' className='text-center'>
                    <td colSpan='4'>Nenhum autor foi encontrado</td>
                </tr>
            )
        }

        return list.map(a => (
            <tr key={a.Id}>
                <td>{a.Id}</td>
                <td>{a.Nome}</td>
                <td>{a.DtCadastro}</td>
                <td className='table-actions'>
                    <button className='btn btn-warning' onClick={() => this.props.modificar(a)}>
                        <i className='fa fa-pencil'></i>
                    </button>
                    <button className='btn btn-danger' onClick={() => this.props.excluir(a)}>
                        <i className='fa fa-trash-o'></i>
                    </button>
                </td>
            </tr>
        ))
    }

    render() {
        return (
            <Content titulo='Autor' subtitulo='Listagem'>
                <table className='table table-hover'>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Nome</th>
                            <th>Dt. Cadastro</th>
                            <th>Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderRows()}
                    </tbody>
                </table>
                <button className='btn btn-success' onClick={this.props.novo}>
                    <i className='fa fa-plus'></i> Novo
                </button>                        
            </Content>
        )
    }
}

const mapStateToProps = state => ({list: state.autor.list})
const mapDispatchToProps = dispatch => bindActionCreators({listar, excluir, modificar, novo}, dispatch)

export default connect(mapStateToProps, mapDispatchToProps)(AutorList)