import React, { Component } from 'react';
import { Table, Alert } from 'reactstrap';
import moment from 'moment'
import axios from 'axios'

class NotesList extends Component {
    static displayName = NotesList.name;

    state = { isLoading: false, error: false, notes: null };

    getNotes = async () => {
        this.setState(s => ({ ...s, error: false, isLoading: true }));
        try {
            const response = await axios.get('api/notes')
            const data = response.data.map(n => ({ ...n, dateCreated: moment(n.dateCreated).format("YYYY-MM-DD HH:mm:ss") }));
            this.setState(s => ({ ...s, notes: data, error: false, isLoading: false }));
        } catch (e) {
            this.setState(s => ({ ...s, notes: null, error: true, isLoading: false }));
        }
    }

    getNote = async (note) => {
        if (!note.textIsTrimed) return;

        try {
            const response = await axios.get(`api/notes/${note.id}`);
            const data = response.data;
            this.setState(s => ({ ...s, notes: s.notes.map(n => n.id === note.id ? { ...n, shortText: data.text, textIsTrimed: false } : n), error: false }));
        } catch (e) {
            this.setState(s => ({ ...s, error: true}));
        }
    }

    componentDidMount() {
        this.getNotes();
    }

    renderNote(note) {
        return (
            <tr key={note.id}>
                <td>{note.dateCreated}</td>
                <td>
                    <div onClick={() => this.getNote(note)}>
                        <pre>
                            {note.shortText}{note.textIsTrimed ? '...' : ''}
                        </pre>
                    </div>
                </td>
            </tr>
        )
    }

    renderNotes(notes) {
        return (
            <Table striped bordered hover size="sm">
                <thead>
                    <tr>
                        <th style={{ width: "20%" }}>Date added</th>
                        <th style={{ width: "80%" }}>Text</th>
                    </tr>
                </thead>
                
                <tbody>
                    {this.state.notes.map(n => this.renderNote(n))}
                </tbody>
            </Table>
        )
    }


    render() {
        const { isLoading, error, notes } = this.state;
        return (
            <div>
                <h2>Notes</h2>
                {isLoading && <p><em>Loading...</em></p>}
                {error && <Alert color="danger">An error occurred, please try again later.</Alert>}
                {notes && this.renderNotes(notes)}
            </div>
        );
    }
}

export default NotesList