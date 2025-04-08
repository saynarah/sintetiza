import { Component } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import { RulesModalComponent } from '../../components/rules-modal/rules-modal.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [ MatIconModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  constructor(private dialog: MatDialog) { }

  reload() {
    location.reload();
  }
  
  openRules() {
    console.log('open')
    this.dialog.open(RulesModalComponent, {
      width: '400px',
      disableClose: true,
    });
  }

}
