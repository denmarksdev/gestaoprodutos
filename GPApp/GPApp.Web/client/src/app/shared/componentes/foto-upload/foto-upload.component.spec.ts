import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FotoUploadComponent } from './foto-upload.component';

describe('FotoUploadComponent', () => {
  let component: FotoUploadComponent;
  let fixture: ComponentFixture<FotoUploadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FotoUploadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FotoUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
