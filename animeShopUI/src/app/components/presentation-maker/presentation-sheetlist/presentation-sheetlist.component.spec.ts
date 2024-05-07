import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PresentationSheetlistComponent } from './presentation-sheetlist.component';

describe('PresentationSheetlistComponent', () => {
  let component: PresentationSheetlistComponent;
  let fixture: ComponentFixture<PresentationSheetlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PresentationSheetlistComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PresentationSheetlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
