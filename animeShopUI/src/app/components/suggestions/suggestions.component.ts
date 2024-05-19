import { Component, OnInit } from '@angular/core';
import { PresentationDTO, PresentationApiClient } from '../../services/ApiClient.nswag';
import { firstValueFrom } from 'rxjs';
import { CommonModule, NgFor } from '@angular/common';


@Component({
  selector: 'ctrs-suggestions',
  standalone: true,
  imports: [NgFor],
  templateUrl: './suggestions.component.html',
  styleUrl: './suggestions.component.scss'
})
export class SuggestionsComponent {

}
