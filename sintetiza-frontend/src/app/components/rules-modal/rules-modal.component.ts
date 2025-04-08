import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-rules-modal',
  imports: [CommonModule, MatDialogModule, MatButtonModule],
  templateUrl: './rules-modal.component.html',
  styleUrl: './rules-modal.component.css'
})
export class RulesModalComponent {

}
