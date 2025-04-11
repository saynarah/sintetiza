import { Component } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import { RulesModalComponent } from '../../components/rules-modal/rules-modal.component';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';


@Component({
  selector: 'app-header',
  standalone: true,
  imports: [ MatIconModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  constructor(
    private router: Router,
    private dialog: MatDialog) { 
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
    }

  openQuestion() {
    this.router.navigate(['/home']);
  }
  
  openRules() {
    this.dialog.open(RulesModalComponent, {
      width: '400px',
      disableClose: true,
    });
  }

  openList() {
    this.router.navigate(['/list']);
  }

}
