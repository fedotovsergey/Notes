import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import NotesList from './pages/notes/NotesList';
import NoteAdd from './pages/notes/NoteAdd';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={NotesList} />
            <Route path='/add' component={NoteAdd} />
      </Layout>
    );
  }
}
