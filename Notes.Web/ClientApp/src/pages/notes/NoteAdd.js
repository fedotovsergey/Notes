import React, { Component } from 'react';
import { Form, FormGroup, Input, Button, Alert } from 'reactstrap';
import { withRouter } from 'react-router-dom'
import axios from 'axios'

class NoteAdd extends Component {
    static displayName = NoteAdd.name;

    state = {
        inProgress: false,
        error: false
    };

    onSubmit = async e => {
        e.preventDefault();
        //Convert formdata to JSON
        const data = [...e.target.elements]
            .filter(c => c.name !== '')
            .reduce((obj, c) => { obj[c.name] = c.value; return obj; }, {});

        this.setState(s => ({ ...s, error: false, inProgress: true }));
        try {
            await axios.post('api/notes', data);
            this.props.history.push('/')
        } catch (e) {
            this.setState(s => ({ ...s, error: true }));
        }
        this.setState(s => ({ ...s, inProgress: false }));
    }

    render() {
        const { error, inProgress } = this.state;
        return (
            <div>
                <h2>Note</h2>
                <Form onSubmit={this.onSubmit}>
                    <fieldset disabled={inProgress}>
                        <FormGroup>
                            <Input type="textarea" name="text" rows="6" required  />
                        </FormGroup>
                        <Button variant="primary" type="submit">Add</Button>
                    </fieldset>
                </Form>
                {error && <Alert color="danger">An error occurred, please try again later.</Alert>}
            </div>
        );
    }
}

export default withRouter(NoteAdd) 