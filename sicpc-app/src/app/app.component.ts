import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, RouterOutlet } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterModule, HttpClientModule ],
  providers: [],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  title = 'sicpc-app';
  isAuthenticated: boolean = false;

  constructor() {
  }
  ngOnInit(): void {
    this.isAuthenticated = localStorage.getItem('token') === 'valid';

  }

  logout(): void {
    localStorage.removeItem('token');
    this.isAuthenticated = false;
    window.location.reload();
  }
}
