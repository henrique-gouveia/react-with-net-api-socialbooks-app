import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import { reduxForm, Field } from 'redux-form'

import { gravar, cancelar } from './autor-actions'
import { AUTOR_FORM } from './autor-consts'

import labelAndInput from '../component/label-and-input'
import Grid from '../layout/grid'
import Content from '../template/content'

class AutorForm extends Component {
    render() {
        const { handleSubmit, gravar, cancelar } = this.props
        return (
            <Content titulo='Autor' subtitulo='Cadastro'>
                <form role='form' className='form-horizontal'>
                    <Field name='Nome' component={labelAndInput} cols='12 4'
                        label='Nome' placeholder='informe o nome' type='text'/>
                    <Field name='DtCadastro' component={labelAndInput} cols='12 4'
                        label='Dt. Cadastro' type='text' readOnly={true}/>
                    <div className='form-group'>
                        <Grid cols='12 4'>
                            <button type='submit' className={'btn btn-primary'}
                                onClick={handleSubmit(data => gravar(data))}>
                                Gravar
                            </button>
                            <button type='button' className='btn btn-default'
                                onClick={cancelar}>
                                Cancelar
                            </button>
                        </Grid>
                    </div>
                </form>                
            </Content>
        )
    }
}

const mapDispatchToProps = dispatch => bindActionCreators({gravar, cancelar}, dispatch)

AutorForm = reduxForm({form: AUTOR_FORM})(AutorForm)
export default connect(null, mapDispatchToProps)(AutorForm)